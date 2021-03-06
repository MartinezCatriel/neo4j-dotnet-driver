﻿// Copyright (c) 2002-2018 "Neo Technology,"
// Network Engine for Objects in Lund AB [http://neotechnology.com]
//
// This file is part of Neo4j.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Linq;
using System.Text;
using Neo4j.Driver.V1;
using static Neo4j.Driver.Internal.IO.PackStream;

namespace Neo4j.Driver.Internal.IO.StructHandlers
{
    internal class PathHandler : IPackStreamStructHandler
    {
        public object Read(PackStreamReader reader, long size)
        {
            // List of unique nodes
            var uniqNodes = new INode[(int) reader.ReadListHeader()];
            for (var i = 0; i < uniqNodes.Length; i++)
            {
                var node = reader.Read() as INode;

                Throw.ProtocolException.IfFalse(node != null, "receivedNode");

                uniqNodes[i] = node;
            }

            // List of unique relationships, without start/end information
            var uniqRels = new Relationship[(int) reader.ReadListHeader()];
            for (var i = 0; i < uniqRels.Length; i++)
            {
                var uniqRel = reader.Read() as Relationship;

                Throw.ProtocolException.IfFalse(uniqRel != null, "receivedUnboundRelationship");

                uniqRels[i] = uniqRel;
            }

            // Path sequence
            var length = (int) reader.ReadListHeader();

            // Knowing the sequence length, we can create the arrays that will represent the nodes, rels and segments in their "path order"
            var segments = new ISegment[length / 2];
            var nodes = new INode[segments.Length + 1];
            var rels = new IRelationship[segments.Length];

            var prevNode = uniqNodes[0];
            nodes[0] = prevNode;
            for (var i = 0; i < segments.Length; i++)
            {
                var relIdx = (int) reader.ReadLong();
                var nextNode = uniqNodes[(int) reader.ReadLong()]; // Start node is always 0, and isn't encoded in the sequence
                // Negative rel index means this rel was traversed "inversed" from its direction
                Relationship rel;
                if (relIdx < 0)
                {
                    rel = uniqRels[(-relIdx) - 1]; // -1 because rel idx are 1-indexed
                    rel.SetStartAndEnd(nextNode.Id, prevNode.Id);
                }
                else
                {
                    rel = uniqRels[relIdx - 1];
                    rel.SetStartAndEnd(prevNode.Id, nextNode.Id);
                }

                nodes[i + 1] = nextNode;
                rels[i] = rel;
                segments[i] = new Segment(prevNode, rel, nextNode);
                prevNode = nextNode;
            }

            return new Path(segments.ToList(), nodes.ToList(), rels.ToList());
        }
    }
}

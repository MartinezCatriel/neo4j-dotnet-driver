﻿// Copyright (c) 2002-2017 "Neo Technology,"
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
#region Designer generated code
#pragma warning disable
namespace Neo4j.Driver.Tck.Tests.TCK
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "driver_api")]
    [Xunit.TraitAttribute("Category", "reset_database")]
    public partial class TestsTheUniformAPIOfTheDriverFeature : Xunit.IClassFixture<TestsTheUniformAPIOfTheDriverFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DriverResultApi.feature"
#line hidden
        
        public TestsTheUniformAPIOfTheDriverFeature()
        {
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Tests the uniform API of the driver", "  1 Access Basic Result Metadata\r\n\r\n  For a plethora of tools, statements being r" +
                    "un are coming from somewhere else, meaning access to metadata about what a\r\n  st" +
                    "atement does is vital for tooling to understand it. For many other use cases as " +
                    "well, access to metadata about what\r\n  a statement did or will do is very useful" +
                    ". Compliant drivers expose this information as a Result Summary.\r\n  The Result S" +
                    "ummary cannot be accessed before the full Result of the statement summarized has" +
                    " been retrieved from Neo4j.\r\n  This is the case for obvious reasons - many state" +
                    "ments execute lazily, and a complete summary is not possible to\r\n  generate unti" +
                    "l the full result is consumed.\r\n\r\n  1.1 Statement type\r\n\r\n  An application may w" +
                    "ant to treat statements differently depending on their type. For instance, an up" +
                    "dating statement\r\n  may be disallowed for a guest application user. A compliant " +
                    "driver will expose the statementtype as a part of the\r\n  Result Summary.\r\n\r\n  1." +
                    "2 Update statistics\r\n\r\n  Neo4j exposes Update Statistics containing basic counte" +
                    "rs tracking the number of things changed by a statement.\r\n  A compliant driver w" +
                    "ill expose update statistics as part of the Result Summary.\r\n\r\n\r\n  2 Result Plan" +
                    "s and Profile\r\n\r\n  To help a user in understanding the performance characteristi" +
                    "cs of executed statements, many tools need to introspect\r\n  the statement plan a" +
                    "nd also access profiling information. This DIP proposes adding this information " +
                    "to the result\r\n  summary API.\r\n\r\n  2.1 Plans and profiles\r\n\r\n  If the user reque" +
                    "sts a Plan (EXPLAIN clause) or a Profile (PROFILE clause) for a statement, it is" +
                    " recorded by Cypher.\r\n  The Plan or the Profile should be made available via the" +
                    " Result Summary by a compliant driver.\r\n\r\n  2.2 Plans\r\n\r\n  Plans are nodes in a " +
                    "plan tree structure. For each Plan, Cypher records a name, a map of arguments, t" +
                    "he set of\r\n  identifiers influenced by executing this part of the plan and all e" +
                    "xisting child nodes in the plan tree.\r\n  This information should be made availab" +
                    "le for each Plan by a compliant driver. The root Plan should be made\r\n  availabl" +
                    "e via the Result Summary by a compliant driver.\r\n\r\n  2.3 Profiled Plans\r\n\r\n  If " +
                    "profiling a statement, additional information is available for each Profiled Pla" +
                    "n, namely the number of db hits\r\n  caused by executing this part of the plan and" +
                    " the number of rows processed by executing this part of the plan.\r\n  This additi" +
                    "onal information should be made available for each Profiled Plan by a compliant " +
                    "driver. The root\r\n  Profiled Plan should be made available via the Result Summar" +
                    "y by a compliant driver.\r\n\r\n  3 Notifications\r\n\r\n  Notifications provide extra i" +
                    "nformation for a user executing a statement. They can be warnings about problema" +
                    "tic\r\n  queries or other valuable information that can be presented in a client. " +
                    "Unlike errors, notifications do not affect\r\n  the execution of a statement.\r\n\r\n " +
                    " 3.1. Notifications and Status Codes\r\n\r\n  Notifications are a type of [Neo4j Sta" +
                    "tus Code](http://neo4j.com/docs/stable/status-codes.html), specifically,\r\n  noti" +
                    "fications have the classification ClientNotification. Any statement may include " +
                    "Notifications as part of its\r\n  result, and compliant drivers are expected to gi" +
                    "ve the user access to them.\r\n\r\n  Unlike failures, notifications are expected to " +
                    "be non-intrusive, and should not interrupt program flow.\r\n\r\n  1.2. Input Positio" +
                    "n\r\n\r\n  Some, but not all, notifications include a specific position in the state" +
                    "ment that generated the notification.\r\n  This is to help users pinpoint exactly " +
                    "what part of their statement yielded the notification. The input position is\r\n  " +
                    "optional, and consists of a three integer positions:\r\n\r\n  - the offset from the " +
                    "start of the string, starting from 0\r\n\r\n  - the line number, starting from 1\r\n\r\n" +
                    "  - the column number, starting from 1", ProgrammingLanguage.CSharp, new string[] {
                        "driver_api",
                        "reset_database"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void SetFixture(TestsTheUniformAPIOfTheDriverFeature.FixtureData fixtureData)
        {
        }
        
        void System.IDisposable.Dispose()
        {
            this.ScenarioTearDown();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Summarize `Result Cursor`")]
        public virtual void SummarizeResultCursor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Summarize `Result Cursor`", ((string[])(null)));
#line 77
  this.ScenarioSetup(scenarioInfo);
#line 78
    testRunner.Given("running: CREATE (n)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
    testRunner.Then("the `Statement Result` is closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Statement")]
        public virtual void AccessStatement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Statement", ((string[])(null)));
#line 82
  this.ScenarioSetup(scenarioInfo);
#line 83
    testRunner.Given("running: CREATE (:label {name: \"Pelle\"} )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 84
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
    testRunner.And("I request a `Statement` from the `Result Summary`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
    testRunner.Then("requesting the `Statement` as text should give: CREATE (:label {name: \"Pelle\"} )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
    testRunner.And("requesting the `Statement` parameter should give: {}", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Statement parametrised")]
        public virtual void AccessStatementParametrised()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Statement parametrised", ((string[])(null)));
#line 89
  this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "param"});
            table1.AddRow(new string[] {
                        "\"Pelle\""});
#line 90
    testRunner.Given("running parametrized: CREATE (:label {name: {param}} )", ((string)(null)), table1, "Given ");
#line 93
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
    testRunner.And("I request a `Statement` from the `Result Summary`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
    testRunner.Then("requesting the `Statement` as text should give: CREATE (:label {name: {param}} )", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
    testRunner.And("requesting the `Statement` parameter should give: {\"param\":\"Pelle\"}", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check create node, properties and relationships")]
        public virtual void AccessUpdateStatisticsAndCheckCreateNodePropertiesAndRelationships()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check create node, properties and relationships", ((string[])(null)));
#line 98
  this.ScenarioSetup(scenarioInfo);
#line 99
    testRunner.Given("running: CREATE (:label1 {name: \"Pelle\"})<-[:T1]-(:label2 {name: \"Elin\"})-[:T2]->" +
                    "(:label3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 100
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table2.AddRow(new string[] {
                        "nodes created",
                        "3"});
            table2.AddRow(new string[] {
                        "nodes deleted",
                        "0"});
            table2.AddRow(new string[] {
                        "relationships created",
                        "2"});
            table2.AddRow(new string[] {
                        "relationships deleted",
                        "0"});
            table2.AddRow(new string[] {
                        "properties set",
                        "2"});
            table2.AddRow(new string[] {
                        "labels added",
                        "3"});
            table2.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table2.AddRow(new string[] {
                        "indexes added",
                        "0"});
            table2.AddRow(new string[] {
                        "indexes removed",
                        "0"});
            table2.AddRow(new string[] {
                        "constraints added",
                        "0"});
            table2.AddRow(new string[] {
                        "constraints removed",
                        "0"});
            table2.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 101
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check delete node and relationship")]
        public virtual void AccessUpdateStatisticsAndCheckDeleteNodeAndRelationship()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check delete node and relationship", ((string[])(null)));
#line 116
  this.ScenarioSetup(scenarioInfo);
#line 117
    testRunner.Given("init: CREATE (:label1 {name: \"Pelle\"})<-[:T1]-(:label2 {name: \"Elin\"})-[:T2]->(:l" +
                    "abel3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
    testRunner.Given("running: MATCH (n:label1 {name: \"Pelle\"})<-[r:T1]-(:label2 {name: \"Elin\"})-[:T2]-" +
                    ">(:label3) DELETE n,r", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 119
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table3.AddRow(new string[] {
                        "nodes created",
                        "0"});
            table3.AddRow(new string[] {
                        "nodes deleted",
                        "1"});
            table3.AddRow(new string[] {
                        "relationships created",
                        "0"});
            table3.AddRow(new string[] {
                        "relationships deleted",
                        "1"});
            table3.AddRow(new string[] {
                        "properties set",
                        "0"});
            table3.AddRow(new string[] {
                        "labels added",
                        "0"});
            table3.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table3.AddRow(new string[] {
                        "indexes added",
                        "0"});
            table3.AddRow(new string[] {
                        "indexes removed",
                        "0"});
            table3.AddRow(new string[] {
                        "constraints added",
                        "0"});
            table3.AddRow(new string[] {
                        "constraints removed",
                        "0"});
            table3.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 120
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check create index")]
        public virtual void AccessUpdateStatisticsAndCheckCreateIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check create index", ((string[])(null)));
#line 135
  this.ScenarioSetup(scenarioInfo);
#line 136
    testRunner.Given("running: CREATE INDEX on :Label(prop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 137
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table4.AddRow(new string[] {
                        "nodes created",
                        "0"});
            table4.AddRow(new string[] {
                        "nodes deleted",
                        "0"});
            table4.AddRow(new string[] {
                        "relationships created",
                        "0"});
            table4.AddRow(new string[] {
                        "relationships deleted",
                        "0"});
            table4.AddRow(new string[] {
                        "properties set",
                        "0"});
            table4.AddRow(new string[] {
                        "labels added",
                        "0"});
            table4.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table4.AddRow(new string[] {
                        "indexes added",
                        "1"});
            table4.AddRow(new string[] {
                        "indexes removed",
                        "0"});
            table4.AddRow(new string[] {
                        "constraints added",
                        "0"});
            table4.AddRow(new string[] {
                        "constraints removed",
                        "0"});
            table4.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 138
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table4, "Then ");
#line 152
 testRunner.And("running: DROP INDEX on :Label(prop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check delete index")]
        public virtual void AccessUpdateStatisticsAndCheckDeleteIndex()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check delete index", ((string[])(null)));
#line 154
  this.ScenarioSetup(scenarioInfo);
#line 155
    testRunner.Given("init: CREATE INDEX on :Label(prop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
    testRunner.Given("running: DROP INDEX on :Label(prop)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 157
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table5.AddRow(new string[] {
                        "nodes created",
                        "0"});
            table5.AddRow(new string[] {
                        "nodes deleted",
                        "0"});
            table5.AddRow(new string[] {
                        "relationships created",
                        "0"});
            table5.AddRow(new string[] {
                        "relationships deleted",
                        "0"});
            table5.AddRow(new string[] {
                        "properties set",
                        "0"});
            table5.AddRow(new string[] {
                        "labels added",
                        "0"});
            table5.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table5.AddRow(new string[] {
                        "indexes added",
                        "0"});
            table5.AddRow(new string[] {
                        "indexes removed",
                        "1"});
            table5.AddRow(new string[] {
                        "constraints added",
                        "0"});
            table5.AddRow(new string[] {
                        "constraints removed",
                        "0"});
            table5.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 158
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check create constraint")]
        public virtual void AccessUpdateStatisticsAndCheckCreateConstraint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check create constraint", ((string[])(null)));
#line 173
  this.ScenarioSetup(scenarioInfo);
#line 174
    testRunner.Given("running: CREATE CONSTRAINT ON (book:Book) ASSERT book.isbn IS UNIQUE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 175
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table6.AddRow(new string[] {
                        "nodes created",
                        "0"});
            table6.AddRow(new string[] {
                        "nodes deleted",
                        "0"});
            table6.AddRow(new string[] {
                        "relationships created",
                        "0"});
            table6.AddRow(new string[] {
                        "relationships deleted",
                        "0"});
            table6.AddRow(new string[] {
                        "properties set",
                        "0"});
            table6.AddRow(new string[] {
                        "labels added",
                        "0"});
            table6.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table6.AddRow(new string[] {
                        "indexes added",
                        "0"});
            table6.AddRow(new string[] {
                        "indexes removed",
                        "0"});
            table6.AddRow(new string[] {
                        "constraints added",
                        "1"});
            table6.AddRow(new string[] {
                        "constraints removed",
                        "0"});
            table6.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 176
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table6, "Then ");
#line 190
 testRunner.Then("running: DROP CONSTRAINT ON (book:Book) ASSERT book.isbn IS UNIQUE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Update Statistics and check delete constraint")]
        public virtual void AccessUpdateStatisticsAndCheckDeleteConstraint()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Update Statistics and check delete constraint", ((string[])(null)));
#line 192
  this.ScenarioSetup(scenarioInfo);
#line 193
    testRunner.Given("init: CREATE CONSTRAINT ON (book:Book) ASSERT book.isbn IS UNIQUE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 194
    testRunner.Given("running: DROP CONSTRAINT ON (book:Book) ASSERT book.isbn IS UNIQUE", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 195
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "counter",
                        "result"});
            table7.AddRow(new string[] {
                        "nodes created",
                        "0"});
            table7.AddRow(new string[] {
                        "nodes deleted",
                        "0"});
            table7.AddRow(new string[] {
                        "relationships created",
                        "0"});
            table7.AddRow(new string[] {
                        "relationships deleted",
                        "0"});
            table7.AddRow(new string[] {
                        "properties set",
                        "0"});
            table7.AddRow(new string[] {
                        "labels added",
                        "0"});
            table7.AddRow(new string[] {
                        "labels removed",
                        "0"});
            table7.AddRow(new string[] {
                        "indexes added",
                        "0"});
            table7.AddRow(new string[] {
                        "indexes removed",
                        "0"});
            table7.AddRow(new string[] {
                        "constraints added",
                        "0"});
            table7.AddRow(new string[] {
                        "constraints removed",
                        "1"});
            table7.AddRow(new string[] {
                        "contains updates",
                        "true"});
#line 196
    testRunner.Then("requesting `Counters` from `Result Summary` should give", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.TheoryAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Access Statement Type")]
        [Xunit.InlineDataAttribute("read only", "RETURN 1", new string[0])]
        [Xunit.InlineDataAttribute("read write", "CREATE (n) WITH * MATCH (n) RETURN n", new string[0])]
        [Xunit.InlineDataAttribute("write only", "CREATE (n)", new string[0])]
        [Xunit.InlineDataAttribute("schema write", "CREATE INDEX on :Label(prop)", new string[0])]
        [Xunit.InlineDataAttribute("schema write", "DROP INDEX on :Label(prop)", new string[0])]
        public virtual void AccessStatementType(string type, string statement, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Statement Type", exampleTags);
#line 211
  this.ScenarioSetup(scenarioInfo);
#line 212
    testRunner.Given(string.Format("running: {0}", statement), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 213
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 214
    testRunner.Then(string.Format("requesting the `Statement Type` should give {0}", type), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Check that plan and no profile is available")]
        public virtual void CheckThatPlanAndNoProfileIsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that plan and no profile is available", ((string[])(null)));
#line 223
  this.ScenarioSetup(scenarioInfo);
#line 224
    testRunner.Given("running: EXPLAIN CREATE (n) RETURN n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 225
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 226
    testRunner.Then("the `Result Summary` has a `Plan`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 227
    testRunner.And("the `Result Summary` does not have a `Profile`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "plan method",
                        "result"});
            table8.AddRow(new string[] {
                        "operator type",
                        "ProduceResults"});
#line 228
    testRunner.And("requesting the `Plan` it contains:", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "plan method",
                        "type"});
            table9.AddRow(new string[] {
                        "identifiers",
                        "[\"n\"]"});
            table9.AddRow(new string[] {
                        "children",
                        "list of plans"});
            table9.AddRow(new string[] {
                        "arguments",
                        "map of string, values"});
#line 231
    testRunner.And("the `Plan` also contains method calls for:", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Check that no plan or no profile is available")]
        public virtual void CheckThatNoPlanOrNoProfileIsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that no plan or no profile is available", ((string[])(null)));
#line 237
  this.ScenarioSetup(scenarioInfo);
#line 238
    testRunner.Given("running: CREATE (n) RETURN n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 239
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 240
    testRunner.Then("the `Result Summary` does not have a `Plan`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 241
    testRunner.And("the `Result Summary` does not have a `Profile`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Check that plan and profile is available")]
        public virtual void CheckThatPlanAndProfileIsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that plan and profile is available", ((string[])(null)));
#line 243
  this.ScenarioSetup(scenarioInfo);
#line 244
    testRunner.Given("running: PROFILE CREATE (n) RETURN n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 245
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 246
    testRunner.Then("the `Result Summary` has a `Profile`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 247
    testRunner.And("the `Result Summary` has a `Plan`", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "plan method",
                        "result"});
            table10.AddRow(new string[] {
                        "operator type",
                        "ProduceResults"});
            table10.AddRow(new string[] {
                        "db hits",
                        "0"});
            table10.AddRow(new string[] {
                        "records",
                        "1"});
#line 248
    testRunner.And("requesting the `Profile` it contains:", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "plan method",
                        "type"});
            table11.AddRow(new string[] {
                        "identifiers",
                        "[\"n\"]"});
            table11.AddRow(new string[] {
                        "children",
                        "list of profiled plans"});
            table11.AddRow(new string[] {
                        "arguments",
                        "map of string, values"});
#line 253
    testRunner.And("the `Profile` also contains method calls for:", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Check that no notification is available")]
        public virtual void CheckThatNoNotificationIsAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that no notification is available", ((string[])(null)));
#line 260
  this.ScenarioSetup(scenarioInfo);
#line 261
    testRunner.Given("running: CREATE (n) RETURN n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 262
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 263
    testRunner.Then("the `Result Summary` `Notifications` is empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Xunit.FactAttribute()]
        [Xunit.TraitAttribute("FeatureTitle", "Tests the uniform API of the driver")]
        [Xunit.TraitAttribute("Description", "Check that notifications are available")]
        public virtual void CheckThatNotificationsAreAvailable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check that notifications are available", ((string[])(null)));
#line 266
  this.ScenarioSetup(scenarioInfo);
#line 267
    testRunner.Given("running: EXPLAIN MATCH (n),(m) RETURN n,m", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 268
    testRunner.When("the `Statement Result` is consumed a `Result Summary` is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "key",
                        "value"});
            table12.AddRow(new string[] {
                        "code",
                        "\"Neo.ClientNotification.Statement.CartesianProductWarning\""});
            table12.AddRow(new string[] {
                        "title",
                        "\"This query builds a cartesian product between disconnected patterns.\""});
            table12.AddRow(new string[] {
                        "severity",
                        "\"WARNING\""});
            table12.AddRow(new string[] {
                        "description",
                        @"""If a part of a query contains multiple disconnected patterns, this will build a cartesian product between all those parts. This may produce a large amount of data and slow down query processing. While occasionally intended, it may often be possible to reformulate the query that avoids the use of this cross product, perhaps by adding a relationship between the different parts or by using OPTIONAL MATCH (identifier is: (m))"""});
            table12.AddRow(new string[] {
                        "position",
                        "{\"offset\": 0,\"line\": 1,\"column\": 1}"});
#line 269
    testRunner.Then("the `Result Summary` `Notifications` has one notification with", ((string)(null)), table12, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.0.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                TestsTheUniformAPIOfTheDriverFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TestsTheUniformAPIOfTheDriverFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
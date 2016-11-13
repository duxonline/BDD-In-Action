﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BddTraining.Features.Files
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("View Shopping Cart Summary", Description="\tIn order to place an order\r\n\tAs an online shopper\r\n\tI want to view my shopping c" +
        "art summary", SourceFile="Files\\View Shopping Cart Summary.feature", SourceLine=0)]
    public partial class ViewShoppingCartSummaryFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "View Shopping Cart Summary.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "View Shopping Cart Summary", "\tIn order to place an order\r\n\tAs an online shopper\r\n\tI want to view my shopping c" +
                    "art summary", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
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
        
        [TechTalk.SpecRun.ScenarioAttribute("View Shopping Cart Summary", SourceLine=5)]
        public virtual void ViewShoppingCartSummary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Shopping Cart Summary", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "price",
                        "type",
                        "isimported"});
            table1.AddRow(new string[] {
                        "Kindle",
                        "500",
                        "Normal",
                        "true"});
            table1.AddRow(new string[] {
                        "Design Patterns",
                        "50",
                        "Books",
                        "false"});
#line 7
 testRunner.Given("I have the following two products:", ((string)(null)), table1, "Given ");
#line 11
 testRunner.When("I add them to my cart", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "price",
                        "quantity",
                        "subtotal",
                        "Tax"});
            table2.AddRow(new string[] {
                        "Kindle",
                        "500",
                        "1",
                        "500",
                        "75"});
            table2.AddRow(new string[] {
                        "Design Patterns",
                        "50",
                        "1",
                        "50",
                        "0"});
#line 12
 testRunner.Then("My cart summary should look like following:", ((string)(null)), table2, "Then ");
#line 16
 testRunner.And("The total price is $550", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("The tax total is $75", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("The grant total is $625", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
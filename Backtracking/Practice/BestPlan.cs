using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    public class Feature
    {
        public string Name;
        public Feature(string name)
        {
            Name = name;
        }
    }

    public class Plan
    {
        public string Name;
        public double Cost;
        public List<Feature> Features;

        public Plan(string name, double cost, List<Feature> lstFea)
        {
            Name = name;
            Cost = cost;

            Features = new List<Feature>();
            foreach (var f in lstFea)
                Features.Add(f);
        }
    }

    public class PlanSearch
    {
        private List<Plan> AllPlans;    // all plans 
        private List<Feature> SelectedFeatures;  // all features user selected

        private List<Plan> SelectedPlans;  // trace the plan which has user's feature
        private List<Plan> FinalBestPlans; // store the lowest cost plans

        //constructor
        public PlanSearch(List<Plan> allPlans, List<Feature> selectedFeatures)
        {
            AllPlans = new List<Plan>();
            AllPlans = allPlans;

            SelectedFeatures = new List<Feature>();
            SelectedFeatures = selectedFeatures;

            SelectedPlans = new List<Plan>();
            FinalBestPlans = new List<Plan>();
        }

        public List<Plan> GetLowCostPlan()
        {
            return(GetLowCostPlan(AllPlans, SelectedFeatures));
        }

        private List<Plan> GetLowCostPlan(List<Plan> allPlans, List<Feature> selectedFeatures)
        {
            List<Plan> usedPlans = new List<Plan>();
            foreach (var p in allPlans)
            {
                IEnumerable<Feature> intersectFeatures = p.Features.Intersect(selectedFeatures); //search plan
                if (intersectFeatures != null)
                {
                    if (intersectFeatures.Any())
                    {
                        SelectedPlans.Add(p);      //current plan has user's features
                    }
                }

                List<Plan> remainPlans = new List<Plan>();
                List<Feature> remainFeatures = new List<Feature>();
                foreach (var f in (selectedFeatures).Except(p.Features))   //get remained features
                   remainFeatures.Add(f);

                usedPlans.Add(p);
                foreach (var rp in allPlans)    // get remain plans
                {
                    if (!usedPlans.Contains(rp))
                        remainPlans.Add(rp);
                }

                if (remainFeatures.Count == 0)    //find a combination, update the result if cost is less
                {
                    PrintPlans(SelectedPlans);    //for troubleshooting, print out every details 
                    SetBestPlans(SelectedPlans);
                    SelectedPlans.Remove(p);
                }
                else if (remainFeatures.Count > 0 && remainPlans.Count > 0)  //continue to search in remained plans, 
                {
                    GetLowCostPlan(remainPlans, remainFeatures);        //recursive
                    SelectedPlans.Remove(p);
                }
                else
                    SelectedPlans.Remove(p);
            }

            return FinalBestPlans;
        }

        private void SetBestPlans(List<Plan> plans)
        {
            double curCost = 0.0;
            double targetCost;

            foreach (var p in plans)
                curCost = curCost + p.Cost;

            if (FinalBestPlans.Count > 0)
            {
                targetCost = 0.0;
                foreach (var p in FinalBestPlans)
                    targetCost = targetCost + p.Cost;
            }
            else
            {
                targetCost = double.MaxValue;
            }
            
            if (curCost <= targetCost)
            {
                FinalBestPlans.Clear();
                foreach (var p in plans)
                    FinalBestPlans.Add(p);
            }
        }

        public void PrintBestPlan()
        {
            double price = 0.0;
            foreach (var p in FinalBestPlans)
            {
                price = price + p.Cost;
                Console.Write(p.Name + " ");
            }
            Console.Write("   The best plans price is: " + price.ToString());
            Console.WriteLine(); 
        }

        private void PrintPlans(List<Plan> plans)
        {
           double price = 0.0;
           foreach(var p in plans)
           {
               price = price + p.Cost;
             Console.Write( p.Name + " ");
           }
           Console.Write("  Qualified plans price is: " + price.ToString());
           Console.WriteLine(); 
        }
    }
}

using Glasses.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glasses
{
    public class DataAccess
    {
        public  delegate void RefreshListDelegate();
        public static event RefreshListDelegate RefreshList;

        public static List<Agent> GetAgents() => new ObservableCollection<Agent>(DemoPrepareEntities.GetContext().Agents).Where(x => x.IsDeleted == false || x.IsDeleted == null).ToList();

        public static void SaveAgent(Agent agent)
        {
            if(agent.ID == 0)
                DemoPrepareEntities.GetContext().Agents.Add(agent);
            DemoPrepareEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }

        public static List<AgentType> GetAgentTypes()
        {
            return DemoPrepareEntities.GetContext().AgentTypes.ToList();
        }

        public static void DeleteAgent(Agent agent)
        {
            AgentPriorityHistory agentPriority = new AgentPriorityHistory();

            agent.IsDeleted = true;
            DemoPrepareEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }

        public static List<Product> GetProducts()
        {
            return DemoPrepareEntities.GetContext().Products.ToList();
        }

        public static void DeleteProductSale(ProductSale product)
        {
            DemoPrepareEntities.GetContext().ProductSales.Remove(product);
            DemoPrepareEntities.GetContext().SaveChanges();
            RefreshList?.Invoke();
        }
    }
}

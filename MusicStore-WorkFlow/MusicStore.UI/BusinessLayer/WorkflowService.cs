using MusicStore.API.DataLayer;
using MusicStore.API.DataLayer.Models;
using MusicStore.UI.DataLayer;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace MusicStore.API.BusinessLayer
{
    public class WorkflowService
    {

        public JObject BuildMusicStoreOperator()
        {
            MusicStoreTableServices __tableService = new MusicStoreTableServices();
            IList<Table> tables = __tableService.ReadSchema();
        
            int __opertorCnt = 0;
            int __linkCnt = 0;
            JObject workFlowData =
                new JObject(
                new JProperty("operators",
                                new JArray(
                                    from p in tables
                                    select new JObject(
                                        new JProperty(string.Format("operator_{0}", p.Name),
                                        new JObject(
                                        new JProperty("top", CalculatePosition(++__opertorCnt)),
                                        new JProperty("left", CalculatePosition(__opertorCnt)),
                                        new JProperty("properties",
                                            new JObject(
                                                new JProperty("title", p.Name),
                                                //new JProperty("uncontained", true),
                                                new JProperty("inputs",
                                                    new JArray(
                                                        from f in p.Fields
                                                        select new JObject(
                                                            new JProperty(f.Name,
                                                            new JObject(
                                                                new JProperty("label", f.Name)
                                                                ))))),
                                                    new JProperty("outputs",
                                                    new JArray(
                                                        from f in p.Fields
                                                        where f.IsPrimaryKey
                                                        select new JObject(
                                                            new JProperty(f.Name,
                                                            new JObject(
                                                                new JProperty("label", f.Name)
                                                                ))))))))))))
                                                                           ,
                           new JProperty("links",
                           new JArray(
                            from p in tables
                            where p.Fields.Where(x => x.IsForeignKey).Any()
                            select new JArray(
                                     from f in p.Fields
                                     where f.IsForeignKey
                                     select new JObject(
                                         new JProperty(string.Format("link_{0}", ++__linkCnt),
                                         new JObject(
                                               new JProperty("fromOperator", string.Format("operator_{0}", f.ForiegnKey.ParentTableName)),
                                               new JProperty("fromConnector", f.ForiegnKey.PrimaryColumnName),
                                               new JProperty("toOperator", string.Format("operator_{0}", p.Name)),
                                               new JProperty("toConnector", f.Name)))))))

            );

            return workFlowData;

        }

        private int CalculatePosition(int _currentPosition)
        {
            return (_currentPosition - 1) * 80;
        }

    }
}

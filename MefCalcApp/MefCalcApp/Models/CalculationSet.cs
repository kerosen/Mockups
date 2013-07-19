using MefCalcApp.Calculator;
using SharedContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MefCalcApp.Models
{
    public class CalculationSet
    {
        public int Param1 { get; set; }
        public int Param2 { get; set; }

        /// <summary>
        /// The submit action for current form.
        /// </summary>
        [Required]
        [ScaffoldColumn(false)]
        public string submitAction { get; set; }

        public CalculationSet()
        {
        }

        public CalculationSet(int param1, int param2)
            : this()
        {
            this.Param1 = param1;
            this.Param2 = param2;
        }

        public IEnumerable<ICalculationService> GetCalculationServices()
        {
            var catalog = new DirectoryCatalog(@"../PluginsLib/bin/Debug/");
            var container = new CompositionContainer(catalog);

            var pluginRepository = new PluginRepository()
            {
                CalculationServices = container.GetExportedValues<ICalculationService>()
            };

            return pluginRepository.CalculationServices;
        }

        public ICalculationService GetCalculationService(string methodName)
        {
            var calculationServices = GetCalculationServices();
            var calculationService = calculationServices.Where(cs => cs.MethodName == methodName).FirstOrDefault();

            return calculationService;
        }
    }
}
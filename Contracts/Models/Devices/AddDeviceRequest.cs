using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod34.Contracts.Devices
{
    public class AddDeviceRequest
    {
        [Required] // Указываем все параметры как обязательные
        public string Name { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        // Указываем допустимый диапазон значений и даже текст ошибки в случае нарушения
      //  [Range(120, 220, ErrorMessage = "Поддерживаются устройства с напряжением от {1} до {2} вольт")]
        public int CurrentVolts { get; set; }
        [Required]
        public bool GasUsage { get; set; }
        [Required]
        public string Location { get; set; }
    }
}

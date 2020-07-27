using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Socket
{
	class Program
	{
		public static void Main(String[] args)
		{
			var Devices = GetUSBDevices();
			foreach(var Device in Devices)
			{
				Console.WriteLine(Device.DeviceID + " -> " + Device.Description);
			}
		}

		static List<USBDeviceInfo> GetUSBDevices()
		{
			List<USBDeviceInfo> Devices = new List<USBDeviceInfo>();

			ManagementObjectCollection Collection;
			using (var Searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
			{
				Collection = Searcher.Get();
			}

			foreach (var Device in Collection)
			{
				Devices.Add(new USBDeviceInfo(
					(string)Device.GetPropertyValue("DeviceID"),
					(string)Device.GetPropertyValue("PNPDeviceID"),
					(string)Device.GetPropertyValue("Description")
				));
			}

			Collection.Dispose();
			return Devices;
		}

		class USBDeviceInfo
		{
			public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
			{
				this.DeviceID = deviceID;
				this.PnpDeviceID = pnpDeviceID;
				this.Description = description;
			}
			public string DeviceID { get; private set; }
			public string PnpDeviceID { get; private set; }
			public string Description { get; private set; }
		}
	}
}

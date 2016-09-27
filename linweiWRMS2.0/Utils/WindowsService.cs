using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace linweiWRMS2._0.Utils {
    /// <summary>
    /// windows服务类
    /// </summary>
    class WindowsService {
        /// <summary>
        /// 判断某个服务是否启动
        /// </summary>
        /// <param name="serviceName"></param>
        public static bool ISStart(string serviceName) {
            bool result = true;
            try {
                ServiceController[] services = ServiceController.GetServices();
                foreach (ServiceController service in services) {
                    if (service.ServiceName.ToLower().Equals(serviceName.ToLower())) {
                        if ((service.Status == ServiceControllerStatus.Stopped)
                            || (service.Status == ServiceControllerStatus.StopPending)) {
                            result = false;
                        }
                    }
                }
            } catch {
                result = false;
            }
            return result;
        }
    }
}

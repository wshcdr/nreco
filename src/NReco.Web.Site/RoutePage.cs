﻿#region License
/*
 * NReco library (http://code.google.com/p/nreco/)
 * Copyright 2008 Vitaliy Fedorchenko
 * Distributed under the LGPL licence
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.Routing;

namespace NReco.Web.Site {
	
	public class RoutePage : Page, IRouteAware {
		public RoutePage() { }

		public RequestContext RouteContext { get; set; }

		IDictionary<string, object> _PageContext = null;

		public IDictionary<string,object> PageContext {
			get {
				if (_PageContext==null) {
					_PageContext = new Dictionary<string, object>();
					if (RouteContext != null) {
						foreach (var entry in RouteContext.RouteData.Values)
							_PageContext[entry.Key] = entry.Value;
						if (RouteContext.RouteData.DataTokens!=null)
							foreach (var entry in RouteContext.RouteData.DataTokens)
								_PageContext[entry.Key] = entry.Value;
					}
				}
				return _PageContext;
			}
		}

	}
}
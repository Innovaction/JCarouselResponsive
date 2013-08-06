/*
' Copyright (c) 2012  DotNetNuke Corporation
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.Security;


namespace DotNetNuke.Modules.JCarouselResponsive
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from JCarouselResponsiveModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : JCarouselResponsiveModuleBase, IActionable
    {
        


        #region Event Handlers

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Load += new System.EventHandler(this.Page_Load);
        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Page_Load runs when the control is loaded
        /// </summary>
        /// -----------------------------------------------------------------------------
        private void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    //Consult web service

                    //Grab answer

                    //Replace template

                    //Place it in literal

                    DotNetNuke.Web.Client.ClientResourceManagement.ClientResourceManager.RegisterScript(this.Page, "~/Resources/Shared/Scripts/jquery.mousewheel.min.js");
                    DotNetNuke.Web.Client.ClientResourceManagement.ClientResourceManager.RegisterScript(this.Page, "~/Resources/Shared/Scripts/jquery.touchSwipe.min.js");
                    DotNetNuke.Web.Client.ClientResourceManagement.ClientResourceManager.RegisterScript(this.Page, "~/Resources/Shared/Scripts/jquery.ba-throttle-debounce.min.js");
                    DotNetNuke.Web.Client.ClientResourceManagement.ClientResourceManager.RegisterScript(this.Page, "~/Resources/Shared/Scripts/jquery.transit.min.js");
                    DotNetNuke.Web.Client.ClientResourceManagement.ClientResourceManager.RegisterScript(this.Page, "~/Resources/Shared/Scripts/jquery.carouFredSel-6.2.1-packed.js");

                    try
                    {
                        LiteralCarousel.Text = GenerateHeader() + GenerateTemplate() + GenerateFooter();
                    }
                    catch
                    {
                        LiteralCarousel.Text = "Deberá ir a settings a grabar la primer configuración. Gracias";
                    }
                }
                catch (Exception exc) //Module failed to load
                {
                    Exceptions.ProcessModuleLoadException(this, exc);
                }
            }
        }

        #endregion

        #region Optional Interfaces

        public ModuleActionCollection ModuleActions
        {
            get
            {
                ModuleActionCollection Actions = new ModuleActionCollection();
                Actions.Add(GetNextActionID(), Localization.GetString("EditModule", this.LocalResourceFile), "", "", "", EditUrl(), false, SecurityAccessLevel.Edit, true, false);
                return Actions;
            }
        }

        #endregion


        private string GenerateTemplate()
        {
            var myController = new CarouselDataController();
            var myList = myController.List();
            var Template = default(string);

            foreach (var element in myList)
            {
                Template += @"<li><div class=""DivItemImage""><img src=""" +  element.ImagenURL  + @""" alt=""=)"" class=""ImgItemImage""> </div> <div class=""DivItemDescription""><span class=""SpanItemDesctiptionText"">" + element.Texto + @"</span></div></li>  ";
                
            }

            return Template;
        }
        private string GenerateHeader()
        {
            try
            {
                var myHeader = @"<HEAD>
		
		                   <style type=""text/css"">
                            "
                                + Settings["StyleSheetModuleID"].ToString() +
                               @" </style>

    

			                    <script type=""text/javascript"" language=""javascript"">
				                    $(function() {
				
				                    $('#foo2" + ModuleId.ToString() + @"').carouFredSel({
					                    auto: false,
					                    prev: '#prev2',
					                    next: '#next2',
					                    pagination: ""#pager2"",
					                    mousewheel: false,
					                    responsive: true,
					                    items:	{
							                    visible:3,
							                    height: """+ Settings["CarouselHeight"].ToString() + @"%""
							                    },
					                    swipe: {
						                    onMouse: false,
						                    onTouch: true
					                    }
					
				                    });
				
				                    })
			                    </script>
			
			
                    </HEAD>

                    <BODY>


                    <!-- Container that contains everything for responsive purposes -->

                    <div class = ""CarouselWrapper_" + ModuleId.ToString() + @""">

                    <!-- Our carousel's div -->
	                    <div class=""list_carousel"">
					                    <ul id=""foo2" + ModuleId.ToString() + @""">";



                myHeader = myHeader.Replace("prev2", "prev2" + ModuleId.ToString());
                myHeader = myHeader.Replace("next2", "next2" + ModuleId.ToString());
                myHeader = myHeader.Replace("pager2", "pager2" + ModuleId.ToString());
                return myHeader;
            }
            catch
            {
                throw new Exception("No stylesheet set");
            }
            
        }

        private string GenerateFooter()
        {

            string myFooter = @"</ul>
					<div class=""clearfix""></div>
					<div class=""left"" ><a id=""prev2"" class=""prev"" href=""#""><img src=""/DesktopModules/JCarouselResponsive/prev.png"" alt="""" style=""max-width:100%;max-height:100%;""></a></div>
					<div class=""right""><a id=""next2"" class=""next"" href=""#""><img src=""/DesktopModules/JCarouselResponsive/next.png"" alt="""" style=""max-width:100%;max-height:100%;""></a></div>
					<div id=""pager2"" class=""pager""></div>
	                    </div>
                    </div>	

                    </BODY>
			
                    </HTML>";

            myFooter = myFooter.Replace("prev2", "prev2" + ModuleId.ToString());
            myFooter = myFooter.Replace("next2", "next2" + ModuleId.ToString());
            myFooter = myFooter.Replace("pager2", "pager2" + ModuleId.ToString());
          
            return myFooter;
        }


    }

    }

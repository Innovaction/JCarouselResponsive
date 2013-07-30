using System;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using System.Data.Sql;



    public class CarouselDataController
    {


        #region "Private Methods"
        private object GetNull(object Field)
        {
            return DotNetNuke.Common.Utilities.Null.GetNull(Field, DBNull.Value);
        }
        #endregion

        #region "Public Methods"
        public CarouselDataInfo Get(int carouselDataID)
        {

            return (CarouselDataInfo)CBO.FillObject(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("CarouselDataGet", carouselDataID), typeof(CarouselDataInfo));

        }

        public List<CarouselDataInfo> List()
        {

            return CBO.FillCollection<CarouselDataInfo>(DotNetNuke.Data.DataProvider.Instance().ExecuteReader("CarouselDataList"));

        }


        public void Add(CarouselDataInfo objCarouselData)
        {

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("CarouselDataAdd", GetNull(objCarouselData.ImagenURL), GetNull(objCarouselData.Texto), GetNull(objCarouselData.Link), GetNull(objCarouselData.SeccionID));

        }

        public void Update(CarouselDataInfo objCarouselData)
        {

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("CarouselDataUpdate", GetNull(objCarouselData.CarouselDataID), GetNull(objCarouselData.ImagenURL), GetNull(objCarouselData.Texto), GetNull(objCarouselData.Link), GetNull(objCarouselData.SeccionID));

        }

        public void Delete(CarouselDataInfo objCarouselData)
        {

            DotNetNuke.Data.DataProvider.Instance().ExecuteNonQuery("CarouselDataDelete", GetNull(objCarouselData.CarouselDataID));

        }
        #endregion


    }




    public class CarouselDataInfo
    {

        #region "Private Members"
        int _carouselDataID;
        string _imagenURL;
        string _texto;
        string _link;
        #endregion
        int _seccionID;

        #region "Constructors"
        public CarouselDataInfo()
        {
        }

        public CarouselDataInfo(int carouselDataID, string imagenURL, string texto, string link, int seccionID)
        {
            this.CarouselDataID = CarouselDataID;
            this.ImagenURL = ImagenURL;
            this.Texto = Texto;
            this.Link = Link;
            this.SeccionID = SeccionID;
        }
        #endregion

        #region "Public Properties"

        public int CarouselDataID
        {
            get { return _carouselDataID; }
            set { _carouselDataID = value; }
        }

        public string ImagenURL
        {
            get { return _imagenURL; }
            set { _imagenURL = value; }
        }

        public string Texto
        {
            get { return _texto; }
            set { _texto = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public int SeccionID
        {
            get { return _seccionID; }
            set { _seccionID = value; }
        }
        #endregion

    }

    public class DefaultStyleSheet
    {
        public static string StyleSheet = @".CarouselWrapper 
{
	width:60%;
	background-color: #FF0030;
	
}
.list_carousel {
	background-color: white;
	width: 80%;
	margin: 0 auto;
	/*importantisimo para las imagenes*/
	position:relative; /*hace que el position absolute llegue aca*/
}
.list_carousel ul {
	margin: 0;
	padding: 0;
	list-style: none;
	display: block;
}
.list_carousel li {
	text-align: center;
	border: 1px solid #999;
	width: 50px;
	height: 50px;
	padding: 0;
	margin: 6px;
	display: block;
	float: left;
}

/*Buttons*/

.left
{
	position: absolute;
	left: -8.5%;
	z-index: 79;
	top: 40%;
	height: 20%;
	width:3%;
}

.right
{
	position: absolute;
	right: -8%;
	z-index: 79;
	top: 40%;
	height: 20%;
	width:3%;
}

/*Image part of the Item*/

.ImgItemImage
{
	max-height:100%;
	max-width: 100%;
}

.DivItemImage 
{
	height:75%;
}



/*Description part of the Item*/

	.DivItemDescription
	{
		height: 25%;
		font-size: 0.6em;
		vertical-align: middle;
	}


@media screen and (min-width: 890px)
{
	.DivItemDescription
	{
		font-size: 0.81em;
	}
}


@media screen and (min-width: 1150px)
{
	.DivItemDescription
	{
		font-size: 1.05em;
	}
}

.SpanItemDesctiptionText
{
	top:12.5%; /* Because it's 50% (centered) of 25% which is the length of our div relative to the outer div */
	position: relative;
}
";
    }

    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik, @toddanglin
    //Facebook: facebook.com/telerik
    //=======================================================











//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik, @toddanglin
//Facebook: facebook.com/telerik
//=======================================================


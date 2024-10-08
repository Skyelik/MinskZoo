using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TastyTravels
{
    public partial class ZooContact : Form
    {
        private GMapControl gmap;
        private GMapOverlay markersOverlay;

        public ZooContact()
        {
            InitializeComponent();
            InitializeGMap();
        }

        private void InitializeGMap()
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Position = new PointLatLng(53.84975730265539, 27.634009868611912);
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 15;
            gMapControl1.AutoScroll = true;

            markersOverlay = new GMapOverlay("markers");
            var marker = new GMarkerGoogle(new PointLatLng(53.84975730265539, 27.634009868611912), GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);


        }

       
    }
}

var mapId = "map";
var latitude = 41.000334;
var longitude =  29.047346;
var mapName = "Production Provider";
var zoomLevel = 16;
var iconUrl = '~/images/ikon.jpg';
var scrollable = false;
var disableDefaultUI = false;
var draggableMarker = false;
var marker;
var map;
var contentString = '';
var styles = [
    {"featureType": "all",
        "stylers":[
            {"saturation": 0},
            {"hue": "#e7ecf0"}
        ]
    },
    {"featureType": "road",
        "stylers":[
            {"saturation": -70}
        ]
    },
    {"featureType": "transit",
        "stylers":[
            {"visibility": "off"}
        ]
    },
    {"featureType": "poi",
        "stylers":[
            {"visibility": "off"}
        ]
    },
    {"featureType": "water",
        "stylers":[
            {"visibility": "simplified"},
            {"saturation": -60}
        ]
    }
];





function initialize() {
    var mapOptions = {
        zoom: zoomLevel,
        scrollwheel: scrollable,
        center: new google.maps.LatLng(41.000334, 29.047346,4),
        mapTypeControlOptions: {
            mapTypeIds: [mapName]
        },
        disableDefaultUI: disableDefaultUI,
        panControl: false,
        zoomControl: true,
        scaleControl: true
    };
    var div = document.getElementById(mapId);
    var map = new google.maps.Map(div, mapOptions);
    var styledMapType = new google.maps.StyledMapType(styles, { name: mapName });
    map.mapTypes.set(mapName, styledMapType);
    map.setOptions({styles: styles});



    /***************** MARKER *********************************/
    marker = new google.maps.Marker({
        map:map,
        draggable:draggableMarker,
        icon: iconUrl,
        animation: google.maps.Animation.DROP,
        position: new google.maps.LatLng(41.000334,29.047346,4)
    });
    // google.maps.event.addListener(marker, 'click', toggleBounce);


    
}



function toggleBounce() {
    if (marker.getAnimation() != null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}

google.maps.event.addDomListener(window, 'load', initialize);
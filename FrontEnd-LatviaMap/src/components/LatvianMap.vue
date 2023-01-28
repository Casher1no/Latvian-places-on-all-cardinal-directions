<template>
  <h1 style="text-transform: uppercase">Furthest Latvian places on cardinal directions</h1>
  <div id="map" class="position-absolute top-50 start-50 translate-middle map-frame"></div>
</template>

<script>
import axios from "axios";
import leaflet from "leaflet";

export default {
  name: 'LatvianMap',
  
  mounted () {
    let map
    let rigaCoord =[56.9718359, 23.9639288]
    map = leaflet.map('map').setView( rigaCoord, 7)

    leaflet.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 19,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    }).addTo(map); 
    
    let api = 'https://localhost:7219/api/latvia/cardinal-places';
    axios.get(api).catch(function (e) {
      throw new Error(e);
    }).then(response => {
      
      Object.values(response.data).forEach(data => {
        let marker = leaflet.marker([data.dD_N, data.dD_E]).addTo(map); 
        marker.bindPopup("Name: " + data.nosaukums);
      })
    })
  },
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped >
#map { 
  height: 80%;
  width: 80%;
}

.map-frame{
  border-radius: 2%;
  box-shadow: rgba(0, 0, 0, 0.2) 0px 12px 28px 0px, rgba(0, 0, 0, 0.1) 0px 2px 4px 0px, rgba(255, 255, 255, 0.05) 0px 0px 0px 1px inset;
}

h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

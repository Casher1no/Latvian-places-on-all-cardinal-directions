<template>
  <div id="map">
    
  </div> 
</template>

<script>
import axios from "axios";
import leaflet from "leaflet";

export default {
  name: 'LatvianMap',
  
  setup () {
    
    let api = 'https://localhost:7219/api/latvia/further-places';
    axios.get(api).then(response => {
      let north = [response.data.furthestNorth.dD_N, response.data.furthestNorth.dD_E];
      let south = [response.data.furthestSouth.dD_N, response.data.furthestSouth.dD_E];
      let west = [response.data.furthestWest.dD_N, response.data.furthestWest.dD_E];
      let east = [response.data.furthestEast.dD_N, response.data.furthestEast.dD_E];
      
      let map
      let rigaCoord =[56.9718359, 23.9639288]
      map = leaflet.map('map').setView( rigaCoord, 7)

      leaflet.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
      }).addTo(map);

      leaflet.marker(north).addTo(map);
      leaflet.marker(south).addTo(map);
      leaflet.marker(west).addTo(map);
      leaflet.marker(east).addTo(map);
    })
  },
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#map { 
  height: 800px;
  width: 1000px;
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

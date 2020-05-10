<template>
  <div class="content" style="overflow: scroll">
    <Login v-if="!this.logged" />
    <div v-else>
      <h1>Your Pets</h1>
      <table>
        <tr>
          <th>Photo:</th>
          <th>Name:</th>
          <th>ID:</th>
          <th>QrCode:</th>
          <th>Last Seen:</th>
        </tr>
        <tr v-for="(pet, index) in user.pets" :key="index">
          <td style="padding: 0; width: 150px">
            <img :src="getImgUrl(pet.petId + pet.photoExt)" width="150px" height="150px" />
          </td>
          <td>{{pet.petName}}</td>
          <td>{{pet.petId}}</td>
          <td style="text-align: center">
            <qrcode :qrcode="'http://localhost:8080/FoundPet?id=' + pet.petId"/>
            <br />
            <div>{{'http://localhost:8080/#/FoundPet/' + pet.petId}}</div> 
          </td>
          <td style="width:400px; text-align: center">
            <iframe
              :src="'https://maps.google.com/maps?q='+pet.lastGeoLocations[0].latitude+','+pet.lastGeoLocations[0].longitude+'&hl=pt-br&z=14&amp;output=embed'"
              width="380"
              height="200"
              frameborder="0"
              style="border:0;"
              allowfullscreen
              aria-hidden="false"
              tabindex="0"
            ></iframe>
            <br />
            <small
              class="txt-center"
            >{{pet.lastGeoLocations[0].latitude+','+pet.lastGeoLocations[0].longitude}}</small>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import Login from "../Login/Login.vue";
import axios from 'axios';
import qrcode from "../_shared/_qrcode";

export default {
  components: {
    Login,
    qrcode
  },
  data() {
    return {
      logged: true,
      location: "",
      user: []
    };
  },
  created() {
    var owner_id = this.$route.params.owner_id ? this.$route.params.owner_id : 1;
    axios.get('http://localhost:5000/api/Owner/' + owner_id)
    .then(response => {
      if (response) {
        this.user = response.data;
      }
    })
    .catch(error => {
      console.log(error);
    });
  },
  methods: {
    getImgUrl(pic) {
      return require("../../../public/petphotos/" + pic);
    },
  }
};
</script>

<style scoped>
.qrcode {
  display: block;
}
table {
  border-collapse: collapse;
  background-image: linear-gradient(to top, white, transparent);
  overflow: hidden;
  width: 100%;
  border-radius: 10px;
  box-shadow: 0 0 15px gainsboro;
}

th,
td {
  text-align: left;
  font-size: 16px;
  padding: 10px;
}
tr {
  box-shadow: 0 5px 5px gainsboro;
}
td img {
  border-radius: 16px;
  margin: 0;
}

th {
  background-color: var(--cor-p1-pri);
  color: white;
}
</style>
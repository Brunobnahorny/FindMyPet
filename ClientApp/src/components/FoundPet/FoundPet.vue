<template>
  <div class="content" style="overflow: scroll">
    <h1>Did you find this one?</h1>
    <transition name="slide-fade" mode="out-in">
      <table>
        <tr>
          <th>Photo:</th>
          <th>Name:</th>
          <th>ID:</th>
          <th>Last Seen:</th>
        </tr>
        <tr v-if="!loading">
          <td style="padding: 0; width: 150px">
            <img :src="getImgUrl(pet.petId + pet.photoExt)" width="150px" height="150px" />
          </td>
          <td>{{pet.petName}}</td>
          <td>{{pet.petId}}</td>
          <td style="width:400px; text-align: center">
            <iframe
              v-if="userlocation"
              :src="'https://maps.google.com/maps?q='+userlocation.coords.latitude+','+userlocation.coords.longitude+'&hl=pt-br&z=14&amp;output=embed'"
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
            >{{userlocation.coords.latitude+','+userlocation.coords.longitude}} - {{userlocation.coords.accuracy}}</small>
          </td>
        </tr>
      </table>
    </transition>
    <div v-if="!loading">
      <h1>Give the owner a call</h1>
      <dl>Name:</dl>
      <dd>{{pet.owner.ownerName}}</dd>
      <dl>Phone:</dl>
      <dd>{{pet.owner.phone}}</dd>
      <dl>Email:</dl>
      <dd>{{pet.owner.email}}</dd>
    </div>
    <div class="locationdiv" v-if="!userlocation">
      <h2>
        Please, activate location to help this pet find its owner/best-friend!
        <img
          src="../../assets/location.svg"
        />
      </h2>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      loading: true,
      userlocation: "",
      pet: {},
      pet_id: this.$route.params.pet_id
    };
  },
  created() {
    this.loading = true;
    navigator.geolocation.getCurrentPosition(this.setlocation);
    var _pet_id = this.$route.params.pet_id ? this.$route.params.pet_id : 1;
    axios
      .get("http://localhost:5000/api/Pet/" + _pet_id)
      .then(response => {
        if (response) {
          this.pet = response.data;
          this.loading = false;
        }
      })
      .catch(error => {
        console.log(error);
      });
  },
  watch: {
    loading() {
      setTimeout(this.saveLocation(), 2000);
    }
  },
  methods: {
    setlocation(position) {
      this.userlocation = position;
    },
    getImgUrl(pic) {
      return require("../../../public/petphotos/" + pic);
    },
    saveLocation() {
      if (this.userlocation) {
        var saveloc = {
          accuracy: this.userlocation.coords.accuracy,
          latitude: this.userlocation.coords.latitude,
          longitude: this.userlocation.coords.longitude,
          timeStamp: this.userlocation.timestamp
        };
        axios
          .post("http://localhost:5000/api/FoundPet/" + this.pet_id, saveloc)
          .catch(res => console.log(res));
      }
    }
  }
};
</script>

<style scoped>
.locationdiv {
  display: block;
  width: 100%;
  text-align: center;
}
h2 img {
  z-index: -1;
  position: relative;
  display: block;
  left: 5%;
  top: -60px;
  width: 120px;
  filter: invert(0.5) sepia(1) saturate(2) hue-rotate(330deg);
  opacity: 0.9;
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
td,
dd {
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

th,
dl {
  background-color: var(--cor-p1-pri);
  color: white;
}
</style>
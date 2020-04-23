<template>
  <div class="content">
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
        <tr v-for="(pet, index) in userPets" :key="index">
          <td style="padding: 0; width: 150px">
            <img :src="getImgUrl(pet.photo)" width="150px" height="150px" />
          </td>
          <td>{{pet.name}}</td>
          <td>{{pet.id}}</td>
          <td style="text-align: center">
            <div ref="qrcode">{{'http://localhost:8080/FoundPet?id=' + pet.id}}</div>
            <br />
            <div>{{'http://localhost:8080/#/FoundPet/' + pet.id}}</div>
          </td>
          <td style="width:400px; text-align: center">
            <iframe
              :src="'https://maps.google.com/maps?q=\''+pet.location+'&hl=pt-br&z=14&amp;output=embed'"
              width="380"
              height="200"
              frameborder="0"
              style="border:0;"
              allowfullscreen
              aria-hidden="false"
              tabindex="0"
            ></iframe>
            <br />
            <small class="txt-center">{{pet.location}}</small>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import Login from "../Login/Login.vue";
import * as QRCode from "easyqrcodejs";
export default {
  components: {
    Login
  },
  data() {
    return {
      logged: true,
      location: '',
      userPets: [
        {
          id: "00001",
          name: "Johnnie Piazza",
          location:
            "Rua Professor Bento Águido Vieira, 144 - Trindade - Florianópolis",
          photo: "00001.jpeg"
        },
        {
          id: "00002",
          name: "Jabé domal",
          location:
            "Rua Professor Bento Águido Vieira, 144 - Trindade - Florianópolis",
          photo: "00002.png"
        },
        {
          id: "00003",
          name: "Jabba Hut",
          location: "Rua Delminda Silveira, 144 - Trindade - Florianópolis",
          photo: "00003.png"
        }
      ]
    };
  },
  mounted() {
    this.$refs.qrcode.forEach(e => {
      var content = e.innerHTML;
      e.innerHTML = "";
      new QRCode(e, {
        text: content,
        width: 190,
        height: 190,
        logo: require("../../assets/logo.svg"),
        logoWidth: 91,
        logoHeight: 120,
        logoBackgroundTransparent: true
      });
    });
  },
  methods: {
    getImgUrl(pic) {
      return require("../../assets/Dogs/" + pic);
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
<template>
  <div class="content">
    <h1>Did you find this one?</h1>
    <table>
      <tr>
        <th>Photo:</th>
        <th>Name:</th>
        <th>ID:</th>
        <th>Last Seen:</th>
      </tr>
      <tr v-if="userlocation">
        <td style="padding: 0; width: 150px">
          <img :src="getImgUrl(userPet.photo)" width="150px" height="150px" />
        </td>
        <td>{{userPet.name}}</td>
        <td>{{userPet.id}}</td>
        <td style="width:400px; text-align: center">
          <iframe 
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
          <small class="txt-center">{{userlocation.coords.latitude+','+userlocation.coords.longitude}}</small>
        </td>
      </tr>
    </table>
    <h1>Give the owner a call</h1>
    <dl>Name:</dl>
    <dd>{{userPet.owner.name}}</dd>
    <dl>Phone:</dl>
    <dd>{{userPet.owner.phone}}</dd>
    <dl>Email:</dl>
    <dd>{{userPet.owner.email}}</dd>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userlocation: '',
      userPet: 
        {
          id: "00001",
          name: "Johnnie Piazza",
          photo: "00001.jpeg",
          owner: {
              name: 'Bruno Bee Nahorny',
              phone: '48 99999-3333',
              email: 'bruno.nahorny@gmail.com'
          }
        }
      
    };
  },
  created() {
    navigator.geolocation.getCurrentPosition(this.setlocation);
  },
  methods: {
    setlocation(position) {
      this.userlocation = position;
    },
    getImgUrl(pic) {
      return require("../../assets/Dogs/" + pic);
    },
  }
};
</script>

<style scoped>
table {
  border-collapse: collapse;
  background-image: linear-gradient(to top, white, transparent);
  overflow: hidden;
  width: 100%;
  border-radius: 10px;
  box-shadow: 0 0 15px gainsboro;
}

th,
td, dd {
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

th, dl{
  background-color: var(--cor-p1-pri);
  color: white;
}
</style>
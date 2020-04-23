<template>
  <div class="content">
    <h1>I found this pet...</h1>
    <form class="form">
      <input v-model="name" type="text" class="name entry" placeholder="Your Name" />

      <input v-model="email" type="text" class="email entry" placeholder="Email" />

      <textarea v-model="message" class="message entry" placeholder="Message"></textarea>

      <input type="file" class="file entry" />

      <button class="submit entry" @click="thanks()">Submit</button>
    </form>

    <div class="shadow"></div>
  </div>
</template>

<script>
export default {
    data() {
        return {
            name: '',
            email: '',
            message: '',
            file: '',
        }
    },
    methods: {
        thanks() {
            alert('Thank you, we are looking for it\'s owner!');
            this.name = '';
            this.email = '';
            this.message = '';
            this.file = '';
        },
    },
};
</script>

<style scoped>
.contactBody {
  background-size: cover;
  background-attachment: fixed;
  height: 700px;
}
.title {
  margin: 0 auto;
  width: 50%;
  text-align: center;
  padding-bottom: 10px;
  font-size: 42px;
  color: rgb(252, 252, 252);
}

#title-Tag-Line {
  font-size: 20px;
}
/* This will center the form */
.wrapper {
  width: 80%;
  height: 50%;
  margin: 5% auto 0 auto;
}

/* form animation starts */
.form {
  text-align: center;
  box-shadow: 0px 0px 20px 5px #aaa;
  border-radius: 10px;
  width: 45%;
  height: 500px;
  margin: 30px auto 0 auto;
  padding: 10px 10px;
}

.name {
  background-color: var(--cor-p2-sec);
  border-bottom: 5px solid var(--cor-p2-sec);
  color: white;
  width: 40%;
}

::-webkit-input-placeholder {
  color: white;
  font-size: 20px;
}
.name:hover,
.name:focus {
  background-color: var(--cor-p2-pri);
  border-bottom: 5px solid var(--cor-p2-pri);
  height: 30px;
  width: 90%;
}

.email {
  background-color: var(--cor-p2-sec);
  border-bottom: 5px solid var(--cor-p2-sec);
  height: 50px;
  color: white;
  width: 40%;
}
.email:hover,
.email:focus {
  background-color: var(--cor-p2-pri);
  border-bottom: 5px solid var(--cor-p2-pri);
  height: 30px;
  width: 90%;
}
.message {
  background-color: var(--cor-p2-sec);
  border-bottom: 5px solid var(--cor-p2-sec);
  overflow: hidden;
  height: 100px;
  color: white;
  width: 40%;
}

.message:hover,
.message:focus {
  background-color: var(--cor-p2-pri);
  border-bottom: 5px solid var(--cor-p2-pri);
  height: 100px;
  width: 90%;
}
.file {
  background-color: var(--cor-p2-sec);
  border-bottom: 5px solid var(--cor-p2-sec);
  overflow: hidden;
  width: 60%;
  color: white;
}
.file::-webkit-file-upload-button {
  visibility: hidden;
  width: 120px;
}
.file::before {
  content: 'Upload a photo...';
  color: white;
  font-size: 16px;
}

.file:hover,
.file:focus {
  background-color: var(--cor-p2-pri);
  border-bottom: 5px solid var(--cor-p2-pri);
  width: 90%;
}

.submit {
  border-radius: 5px;
  padding: 10px;
  border: none;
  border-bottom: 5px solid black;
  transform: translateY(-120px);
}

.submit:hover {
  border-bottom: 5px solid black;
  box-shadow: 15px 15px 15px 5px rgba(78, 72, 77, 0.219);
}

.entry {
  display: block;
  margin: 30px auto;
  padding: 10px;
  border-radius: 5px;
  border: none;
  transition: all 0.5s ease 0s;
  box-shadow: 0px 0px 25px 2px #aaa;
}

/* Shadow to make it look like form is floating  */
.shadow {
  box-shadow: 0px 0px 60px 5px #aaa;
  opacity: 0.5;
  border-radius: 100px;
  width: 50%;
  margin: 50px auto 0 auto;
  padding: 0 20px;
  animation: shadow 1.5s infinite;
}
.submit {
  border-radius: 5px;
  padding: 10px;
  width: 150px;
  color: white;
  background-color: var(--cor-p2-pri);
  border: none;
  border-bottom: 5px solid white;
  margin-top: 150px;
}

@keyframes shadow {
  0% {
  }
  50% {
    opacity: 0.8;
    width: 50%;
  }
}
</style>
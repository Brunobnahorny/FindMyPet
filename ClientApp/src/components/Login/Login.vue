<template>
    <div class="login">
        <h1> Login</h1>
        <form >
        <label for="email">
          <span>
            User:
            <span class="required">*</span>
          </span>
          <input type="email" v-model="user" class="input-field" name="email" required value />
        </label>
        <label for="password">
          <span>
            Password:
            <span class="required">*</span>
          </span>
          <input type="password" v-model="pwd" class="input-field" name="password" required value />
        </label>
        <button @click="login">Entrar</button>
      </form>

    </div>
</template>

<script>
    export default {
        data() {
            return {
                user: '',
                pwd: ''
            }
        },
     
     methods: {
         login() {
             this.$route.params.user = this.user;
             this.$route.params.pwd = this.pwd;
             console.log('rodo');
             
         },
     }
    }
</script>

<style scoped>
.login{
    padding-top: 0;
    height: 100%;
    align-content: center;
    text-align: center;
    padding-right: 20%;

}
label {
  display: block;
  margin: 0px 0px 15px 0px;
  text-align: end;
  
}
label > span {
  width: 120px;
  font-weight: bold;
  padding-top: 8px;
  padding-right: 5px;
  text-align: left;
}
span.required {
  color: red;
}
input.input-field {
  box-sizing: border-box;
  -webkit-box-sizing: border-box;
  -moz-box-sizing: border-box;
  border: 1px solid #c2c2c2;
  box-shadow: 1px 1px 4px #ebebeb;
  -moz-box-shadow: 1px 1px 4px #ebebeb;
  -webkit-box-shadow: 1px 1px 4px #ebebeb;
  border-radius: 3px;
  -webkit-border-radius: 3px;
  -moz-border-radius: 3px;
  padding: 7px;
  outline: none;
  width: 48%;
}
.input-field:focus {
  border: 1px solid var(--cor-p1-ter);
}
button {
  outline: none;
  position: absolute;
  right: 23%;
  border: none;
  padding: 8px 15px 8px 15px;
  background-color: var(--cor-p1-cla);
  background-image: linear-gradient(
    45deg,
    var(--cor-p1-sec),
    var(--cor-p1-cla)
  );
  color: #444;
  box-shadow: 1px 1px 4px black;
  border-radius: 3px;
}
button:hover {
  background: #ea7b00;
  color: #fff;
}
button:active {
  transition: 200ms;
  background-image: none;
  box-shadow: 0px 0px 0px;
}
</style>
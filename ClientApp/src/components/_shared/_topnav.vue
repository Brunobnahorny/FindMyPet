<template>
  <div>
    <svg class="navbar" :width="this.screenX">
      <defs>
        <linearGradient id="grad1" x1="0%" y1="0%" x2="100%" y2="100%">
          <stop offset="0%" style="stop-color:#4784cd;stop-opacity:1" />
          <stop offset="100%" style="stop-color:#bbe2f6;stop-opacity:1" />
        </linearGradient>
      </defs>
      <path
        :d="'M0 0 L0 60 q' + this.screenX/2 + ' 60 ' + this.screenX +
         ' 0  L' + this.screenX + ' 0 Z'"
        fill="url(#grad1)"
      />
    </svg>
    <img id="logo" class="logo" alt="findmypet logo" src="../../assets/logo.svg" />

    <p class="txtlogo" id="txtlogo">FindMyPet</p>
    <div>
      <nav>
        <ul>
          <li style="float: left; margin-left: 10%">
            <router-link to="/" as="a">
              <span>Home</span>
            </router-link>
          </li>
          <li>
            <router-link to="/MyPets" as="a">
              <span>MyPets</span>
            </router-link>
          </li>

          <li style="float: right; margin-right: 10%">
            <router-link to="/FoundAPet" as="a">
              <span>Found a pet</span>
            </router-link>
          </li>
        </ul>
      </nav>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      screenX: innerWidth
    };
  },
  mounted() {
    this.$nextTick(() => {
      window.addEventListener("resize", () => {
        this.screenX = window.innerWidth;
      });
      setTimeout(() => {
        document.getElementById("logo").style.width = "96px";
      }, 2000);
      setTimeout(() => {
        document.getElementById("txtlogo").style.visibility = "visible";
      }, 3000);
    });
  },
  beforeDestroy() {
    window.removeEventListener("resize", this.onResize);
  }
};
</script>

<style scoped>
.logo {
  position: absolute;
  margin: auto;
  left: 0;
  right: 0;
  text-align: center;
  z-index: 3;
  top: 16px;
  width: 90%;
  transition-duration: 2000ms;
}
.navbar {
  position: absolute;
  top: 0;
  z-index: 2;
  height: 90px;
  width: 100%;
}
nav {
  position: relative;
  top: 15px;
  margin: auto;
  z-index: 1;
}
nav ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
}
nav li {
  display: inline;
}
nav li a {
  display: inline-table;
  padding-top: 10px;
  vertical-align: bottom;
  padding: 8px 16px;
  text-decoration: none;
  background-color: var(--cor-p1-pri);
  color: var(--cor-p1-cla);
  border-radius: 15px;
  height: 90px;
}
nav li a span {
  display: table-cell;
  vertical-align: bottom;
}
nav li a:hover {
  background-color: var(--cor-p1-sec);
  color: white;
  transition: 1000ms;
  transform: translate(0px, 30px);
}
.active {
  background-color: var(--cor-p1-sec);
  color: white;
}

.txtlogo {
  position: absolute;
  visibility: hidden;
  margin: auto;
  left: 0;
  right: 0;
  top: 125px;
  text-align: center;
  font-weight: bold;
  text-shadow: 2px 2px 5px var(--cor-p1-ter);
  color: var(--cor-p1-pri);
  z-index: 0;
  transition-duration: 800ms;
}
</style>
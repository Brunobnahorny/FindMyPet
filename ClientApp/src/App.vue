<template>
  <div style="height: 100%">
    <meta
      name="viewport"
      content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0"
    />
    <TopNav />
    <Footer />
    <transition name="slide-fade" mode="out-in">
      <router-view :key="$route.fullpath"></router-view>
    </transition>
  </div>
</template>

<script>
import TopNav from "./components/_shared/_topnav";
import Footer from "./components/_shared/_footer";

export default {
  name: "App",
  components: {
    TopNav,
    Footer
  }
};
</script>

<style>
@font-face {
  font-family: "Comic Neue";
  src: url("./assets/Fonts/ComicNeue-Regular.ttf") format("ttf"),
    url("./assets/Fonts/ComicNeue-Bold.ttf") format("ttf");
}
html {
  -ms-overflow-style: none;
}
html::-webkit-scrollbar {
  display: none;
}
body {
  --cor-p1-pri: #de2125;
  --cor-p1-sec: #f1501b;
  --cor-p1-cla: #ede280;
  --cor-p1-ter: #de9c54;
  --cor-p1-qua: #f8a211;

  --cor-p2-pri: #264da4;
  --cor-p2-sec: #4784cd;
  --cor-p2-cla: #eeeae4;
  --cor-p2-ter: #bbe2f6;
  --cor-p2-qua: #cebabb;

  font-family: "Comic Neue", "Courier New", Courier, monospace;

  background-image: url("./assets/paw.svg");
  background-repeat: repeat;

  margin: 0;
  height: 100%;
}
.content {
  position: relative;
  display: block;
  padding: 24px 46px;
  height: 100%;
  overflow: hidden;
}
.content img {
  object-fit: cover;
}
.content::-webkit-scrollbar {
  display: none;
}

/*** TRANSITIONS ***/
.fade-enter {
  opacity: 0;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s ease-out;
}

.fade-leave-to {
  opacity: 0;
}

.slide-fade-enter {
  transform: translateX(10px);
  opacity: 0;
}

.slide-fade-enter-active,
.slide-fade-leave-active {
  transition: all 0.2s ease;
}

.slide-fade-leave-to {
  transform: translateX(-10px);
  opacity: 0;
}

.slide-up-enter {
  transform: translateY(10px);
  opacity: 0;
}

.slide-up-enter-active {
  transition: all 0.2s ease;
}

.slide-up-move {
  transition: transform 0.8s ease-in;
}
</style>

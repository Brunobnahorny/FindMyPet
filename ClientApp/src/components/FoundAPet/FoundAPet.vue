<template>
  <div class="content">
    <h1>I found this pet...<img src="../../assets/speechbubble.svg"/></h1>
    
    <p>If you happen to cross someones pet/best-friend you should let them know!</p>
    <p>They probably are looking for it... And you can help!</p>
    <p style="text-align: center; font-size: 29px; 
  font-weight: bolder;">Just scan its QRCode</p>
  
    <div class="shadow"><img class="qrcodeexample" src="../../assets/qrcodeexample.png"/></div>
  </div>
</template>
<style scoped>
.qrcodeexample {
  width: 20vw;
  max-width: 10vw;
  ;display: block;
  margin:0 auto;
}
h1 {
  padding-top: 50px;
  width: 370px;
  height: 50px;
  overflow: visible;
}
h1 img {
  z-index: -1;
  position: relative;
  display: block;
  text-align: center;
  top: -80px;
  width: 25vw;
  max-width: 200px;
  filter: invert(.5) sepia(1) saturate(2) hue-rotate(330deg);
  opacity: .9;
}  
@media screen and (max-width: 500px) {
  h1  {
    font-size: 25px;
  }
}
</style>
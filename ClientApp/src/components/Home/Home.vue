<template>
    <div class="content">
        <h1> Hi <img class="icon" src="../../assets/paws.png"> friends!</h1><img v-if="screenW > 700" class="johnnie" src="../../assets/johnny.jpeg" align="right">

        <Carrousel :textos="slides" />
         
    
    <p>Tag your pets with QRCodes and whenever someone scan it, you are automatic notified, with their location. The person whom scanned will have acess to your given information, for easy contacting.</p>
    <h2>  Give your little ones the care they already gave to you.</h2>
    </div>
</template>

<script>
import Carrousel from "../../components/_shared/_carrousel";
export default {
    components: {
        Carrousel
    },
    data(){
        return {
            screenW: innerWidth,
            slides: [
                {
                    text: 'We are here to provide a way of tracking your pets with technology!',
                    id: 1
                },
                {
                    text: 'We are here to make best friends reunite again!',
                    id: 2
                },
                {
                    text: 'We are here for you!',
                    id: 3
                }
            ]         
        }
    }
}
</script>

<style scoped>
p {
    font-size: 18px;
    font-weight: bold;
    line-height: 32px;
    margin: 16px 0 24px;
    padding-right: 23%;
    text-indent: 3em;
}
.icon{
    width: 30px;
    margin: 0;
}
.johnnie {
    border-radius: 16px;
    box-shadow: 0 15px 20px black;
    position: absolute;
    z-index: 2;
    right: 5%;
    width: 20%;
}
</style>
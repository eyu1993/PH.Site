<template>
<div style="margin-top:-60px;">
  <v-header></v-header>
  <el-container>
    <el-main>
      <el-row :gutter="30">
      <el-col :span="6"  v-if="indexList.length>0"  v-for="app in indexList" :key="index">
        <div class="grid-content bg-purple">
          <div class="site-img">
            <img src="../../assets/testImg.jpg" alt="">
            <div class="project">
              <p class="project-name">{{app.AppName}}</p>
              <!--<p>213</p>-->
            </div>
            <div class="soft-type" >
             <span>
               <a  v-for="cat in app.Category.slice(0,2)" :key="index">{{cat.Name}}</a>
               <a v-if="app.Category.length>2"><router-link to="/second">更多</router-link> </a>
             </span>
            </div>
          </div>
        </div>
      </el-col>
    </el-row>
    </el-main>
  </el-container>
</div>
</template>

<script>
  import vHeader from "../../components/basicPart/Header.vue"

  export default {
    data() {
      return{
        indexList:[]
      }
    },
    components: {vHeader},
    mounted() {},
    created(){
      axios.get('http://eyu1993.top:9999/api/App')
        .then(response=>{
          console.table(response.data)
          this.indexList=response.data;
          console.table("AAAAA"+this.indexList)
        })
        .catch(error=>{
          console.log(error);
          alert('网络错误，不能访问');
        })
    },
    methods: {},
  }
</script>

<style scoped>
  @import "../../css/home.css";
</style>

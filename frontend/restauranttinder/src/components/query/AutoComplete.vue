<template>
  <div class="autocomplete">
    <input autocomplete="off" type="text" v-model="search" @input="onChange" @keydown.down="onArrowDown" @keydown.up="onArrowUp" @keydown.enter.prevent="onEnter" :placeholder="placeholder" :name="name" :id="id"/>
    <ul v-show="isOpen" class="autocomplete-results">
      <li class="loading" v-if="isLoading">Loading Results...</li> 
      <li v-else v-for="(result, i) in results" :key="i" @click="setResult(result)" class="autocomplete-result" :class="{'is-active':i===arrowCounter}">
          {{result}}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
    name: "autocomplete",
    data() {
        return {
            search: '',
            results: [],
            isOpen: false,
            isLoading: false,
            arrowCounter: 0,
        };
    },
    methods: {
        onChange() {
            //this.$emit('input', this.search);

            if (this.isAsync){
              this.isLoading = true;
            }
            else {
              this.isOpen = true;
              this.filterResults();
            }
        },
        filterResults() {
            this.results = this.choices.filter(choice => {
                return choice.toLowerCase().indexOf(this.search.toLowerCase()) > -1
            });
        },
        setResult(result) {
          this.search = result;
          this.isOpen = false;
          this.$emit('input', this.search);
        },
        onArrowDown() {
          if(this.arrowCounter < this.results.length) {
            this.arrowCounter = this.arrowCounter + 1;
          }
        },
        onArrowUp() {
          if(this.arrowCounter > 0){
            this.arrowCounter = this.arrowCounter - 1;
          }
        },
        onEnter() {
          //this.search = this.results[this.arrowCounter];
          this.setResult(this.results[this.arrowCounter])
          //this.isOpen = false;
          this.arrowCounter = -1;
        },
        handleClickOutside(evt) {
          if(!this.$el.contains(evt.target)){
            this.isOpen = false;
            this.arrowCounter = -1;
          }
        }
    },
    watch: {
      choices: function(value,oldValue){
        if (this.isAsync) {
          this.results = value;
          this.isOpen = true;
          this.isLoading = false;
        }
      }
    },
    props: {
        placeholder: String,
        name: String,
        id: String,
        choices: {
            type: Array,
            required: false,
            default: () => [],
        },
        isAsync: {
          type: Boolean,
          required: false,
          default: false
        }
    },
    mounted(){
      document.addEventListener('click', this.handleClickOutside);
    },
    destroyed(){
      document.removeEventListener('click', this.handleClickOutside);
    }
}
</script>

<style>
.autocomplete {
    position: relative;
    width: 130px;
  }

  input[type=text]{
    width: inherit;
  }

  .autocomplete-results {
    padding: 0;
    margin: 0;
    border: 1px solid #eeeeee;
    height: 120px;
    overflow: auto;
    position: absolute;
    z-index: 100;
    width: inherit;
  }

  .autocomplete-result {
    list-style: none;
    text-align: left;
    padding: 4px 2px;
    cursor: pointer;
    background-color: white;
  }
  .autocomplete-result.is-active,
  .autocomplete-result:hover {
    background-color: #4AAE9B;
    color: white;
  }
</style>

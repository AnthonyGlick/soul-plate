<template>
    <!--Make sure the form has the autocomplete function switched off:-->
  <div class="autocomplete">
    <input type="text" v-model="search" @input="onChange" :placeholder="placeholder" :name="name" :id="id"/>
    <ul v-show="isOpen" class="autocomplete-results">
      <li v-for="(result, i) in results" :key="i" class="autocomplete-result">
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
        };
    },
    methods: {
        onChange() {
            this.isOpen = true;
            this.filterResults();
        },
        filterResults() {
            this.results = this.choices.filter(choice => {
                return choice.toLowerCase().indexOf(this.search.toLowerCase()) > -1
            });
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
    },
}
</script>

<style>
.autocomplete {
    position: relative;
    width: 130px;
  }

  .autocomplete-results {
    padding: 0;
    margin: 0;
    border: 1px solid #eeeeee;
    height: 120px;
    overflow: auto;
  }

  .autocomplete-result {
    list-style: none;
    text-align: left;
    padding: 4px 2px;
    cursor: pointer;
  }

  .autocomplete-result:hover {
    background-color: #4AAE9B;
    color: white;
  }
</style>

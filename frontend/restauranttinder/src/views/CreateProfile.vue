<template>
    <div class="profile-form">   
        <form class="form" v-on:submit.prevent="submitInfo">
        <h1 class="create-profile">Create Profile</h1>
        <div class="error" v-if="$v.user.$invalid">*Please complete all required fields*</div>
            <section>
                <label>*First Name:</label>
                <input type="text" v-model.trim="user.firstName"> 
            </section>
                <div class="error" v-if="!$v.user.firstName.required">*</div>
               
            
            <section>
                <label>*Last Name:</label>
                <input type="text" v-model.trim ="user.lastName">
            </section>
            <div class="error" v-if="!$v.user.lastName.required">*</div>

            <section>
                <label>*Street Address:</label>
                <input type="text" v-model.trim="user.addressOne">
            </section>
                <div class="error" v-if="!$v.user.addressOne.required"></div>

            <section>
                <label>Address 2:</label>
                <input type="text" v-model.trim="user.addressTwo">
            </section>

            <section>
                <label>*City:</label>
                <input type="text" v-model.trim="user.city">
            </section>
                <div class="error" v-if="!$v.user.city.required"></div>

            <section>
                <label>*State:</label>
                <input type="text" v-model.trim="user.state">
            </section>
                <div class="error" v-if="!$v.user.state.required"></div>

            <section>
                <label>*Postal Code:</label>
                <input type="text" v-model.trim="user.postalCode">
                <div class="error" v-if="!$v.user.postalCode.required"></div>
            </section>

            <section class="button">
                <button>Submit</button>
            </section>
        </form>
    </div>
</template>

<script>
import auth from "@/shared/auth";
import {required} from 'vuelidate/lib/validators'

export default {

    data() {
        return {
            user: {
                firstName:null,
                lastName: null,
                addressOne:null,
                addressTwo: null,
                city: null,
                state: null,
                postalCode: null
            },

            username: auth.getUser().sub
        }
    },
    validations: {
        user:{
            firstName: {
                required
            },
            lastName:{
                required
            },
            addressOne:{
                required
            },
            city:{
                required
            },
            state:{
                required
            },
            postalCode:{
                required
            }

        }
    },

methods: {
    /**
     * Navigates the user to the home route.
     * @function
     */
    goHome() {
      this.$router.push("/");
    },    
    submitInfo() {
        fetch(`${process.env.VUE_APP_REMOTE_API}/Account/${this.username}`, {
            method:'PUT',
            headers: {
                "Content-Type":"application/json"
            },
            body: JSON.stringify(this.user)
        }).then((response) => {
            this.goHome();
        }).catch((error) => console.error(error));
    },  
}

}
</script>

<style scoped>
#app > div > form {
    border-radius: 50px;
    background-color:rgb(255,153,51, .8);
    padding: 50px;
    right: 0;
    left: 0;
    margin: auto;
    margin-top: 50px;
    
    
}

.form {
    display: flex;
    flex-direction: column;
    width: 50%;
    position: absolute;
    padding-top: 50px;
    padding-left: 50px;   
    color: white;   
}

.create-profile {
    text-align: center;
}

form section{
    display: flex;
    justify-content:space-between;
    padding: 10px;
    border-radius: 20px;
}

label {
    padding-right: 30px;
}

.button {
    padding: 10px;
    border-radius: 5px;
    justify-content: flex-end;
}

@media screen and (max-width: 768px) {
    .form {
        width: 100%;
    }
    #app > div > form {
        border-radius: 0;
        padding: 50px 25px;
    }
    label {
        text-align: left;
    }
    form section {
        flex-direction: column;
    }
}

</style>
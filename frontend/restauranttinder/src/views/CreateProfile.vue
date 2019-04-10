<template>
    <div class="profile-form">   
        <form class="form" v-on:submit.prevent="submitInfo" >
        <h1 class="create-profile">Create Profile</h1>
            <section>
                <label>First Name:</label>
                <input type="text" v-model.trim="user.firstName">
            </section>
            
            <section>
                <label>Last Name:</label>
                <input type="text" v-model.trim ="user.lastName">
            </section>

            <section>
                <label>Street Address</label>
                <input type="text" v-model.trim="user.streetAddress">
            </section>

            <section>
                <label>State</label>
                <input type="text" v-model.trim="user.state">
            </section>

            <section>
                <label>Zip Code</label>
                <input type="text" v-model.trim="user.zipCode">
            </section>

            <section class="button">
                <button>Submit</button>
            </section>
        </form>
    </div>
</template>

<script>
import auth from "@/shared/auth";
export default {


    data() {
        return {
            user: {
                firstName: '',
                lastName: '',
                streetAddress: '',
                state: '',
                zipCode: ''
            },
            username: auth.getUser().sub
        }
    },
methods: {
    submitInfo() {
        fetch(`${process.env.VUE_APP_REMOTE_API})/Account/${this.username}`, {
            method:'PUT',
            headers: {
                "Content-Type":"application/json",
                "Authorization": 'Bearer ' + auth.getToken() 
            },
            body: JSON.stringify(this.user)
        }).then((response) => {
        }).catch((error) => console.error(error));
    }
}

}
</script>

<style scoped>
#app > div > form {
    border-radius: 50px;
    background-color: orange;
    padding: 50px;
    right: 0;
    left: 0;
    margin: auto;
    margin-top: 50px;
}

.form {
    display: flex;
    flex-direction: column;
    width: 25%;
    position: absolute;
    padding-top: 50px;
    padding-left: 50px;      
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
</style>

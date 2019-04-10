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
                <label>Street Address:</label>
                <input type="text" v-model.trim="user.addressOne">
            </section>

            <section>
                <label>Address 2:</label>
                <input type="text" v-model.trim="user.addressTwo">
            </section>

            <section>
                <label>City:</label>
                <input type="text" v-model.trim="user.city">
            </section>

            <section>
                <label>State:</label>
                <input type="text" v-model.trim="user.state">
            </section>

            <section>
                <label>Postal Code:</label>
                <input type="text" v-model.trim="user.postalCode">
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
                addressOne: '',
                addressTwo: '',
                city: '',
                state: '',
                postalCode: ''
            },
            username: auth.getUser().sub
        }
    },
methods: {
    submitInfo() {
        fetch(`${process.env.VUE_APP_REMOTE_API}/Account/${this.username}`, {
            method:'PUT',
            headers: {
                "Content-Type":"application/json"
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
    background-color: #FF9933;
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

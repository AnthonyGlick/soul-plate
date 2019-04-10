<template>
    <div class="profile-form">   
        <form class="form">
        <h1 class="create-profile">Create Profile</h1>
            <section>
                <label>First Name:</label>
                <input type="text">
            </section>
            
            <section>
                <label>Last Name:</label>
                <input type="text">
            </section>

            <section>
                <label>Street Address</label>
                <input type="text">
            </section>

            <section>
                <label>State</label>
                <input type="text">
            </section>

            <section>
                <label>Zip Code</label>
                <input type="text">
            </section>

            <section class="button">
                <button v-on:click="submitInfo">Submit</button>
            </section>
        </form>
    </div>
</template>

<script>
import auth from "@/shared/auth";
export default {

    props: {
        VUE_APP_REMOTE_API: String,       
    },
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
        fetch(`${this.VUE_APP_REMOTE_API})/Account/${this.username}`, {
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
        padding: 50px 5px;
    }
    label {
        text-align: left;
    }
}

</style>

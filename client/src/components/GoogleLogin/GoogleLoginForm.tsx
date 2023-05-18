import { GoogleLogin } from 'react-google-login'

const clientId = "801059873983-1g644inr6eibjs8mcb5ejm7olt7s994v.apps.googleusercontent.com";

const onSuccess = (res: any) => {
    console.log('Login successfull', res);
}

const onFailure = (res: any) => {
    console.log('Login failed', res);
}

function GoogleLoginForm(){
    return (
        <div id="signin-btn">
            <GoogleLogin
                clientId={clientId}
                onSuccess={onSuccess}
                onFailure={onFailure}
                cookiePolicy={'single_host_origin'}
                isSignedIn={true}
            />
        </div>
    )
}

export default GoogleLoginForm;
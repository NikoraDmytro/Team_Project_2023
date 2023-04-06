import React from 'react'
import { RegistrationForm } from '../components/RegistrationForm'

const RegistrationPage= (): JSX.Element => {
    return (
    <div style={{height: "100vh", display: "flex", alignItems: "center"}}>
        <RegistrationForm />
    </div>
  )
}

export {RegistrationPage}
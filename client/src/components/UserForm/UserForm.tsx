import React, { useState } from 'react';
import {
  Button,
  Dialog,
  MenuItem,
  Select,
  Chip,
  FormControl,
  InputLabel,
  SelectChangeEvent,
} from '@mui/material';
import { Formik, Form } from 'formik';
import ClearIcon from '@mui/icons-material/Clear';
import { InputFormField } from '../InputFormField';
import UserService from '../../services/UserService';
import { User } from '../../models/User';

interface FormValues {
  id: number;
  email: string;
  firstName: string;
  lastName: string;
  patronymic: string;
}

interface UserFormProps {
  open: boolean;
  update: boolean;
  user?: User;
  setClose: () => void;
}

const UserForm = (props: UserFormProps) => {
  const { open, update, user, setClose } = props;

  const initialValues: FormValues = {
    id: update ? user?.id || 0 : 0,
    email: update ? user?.email || '' : '',
    firstName: update ? user?.firstName || '' : '',
    lastName: update ? user?.lastName || '' : '',
    patronymic: update ? user?.patronymic || '' : ''
  };
  
  const submitHandler = async (values: FormValues) => {
    const user: User = {
      id: initialValues.id,
      email: values.email,
      firstName: values.firstName,
      lastName: values.lastName,
      patronymic: values.patronymic,
    }

    if (update){
      await UserService.updateUser(user.id, user);
    }
    else{
      await UserService.createUser(user);
    }
    
    setClose();
  };

  return (
    <Dialog open={open} onClose={setClose}>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {() => (
          <Form className='form'>
            <InputFormField label="Email" name='email' type='text' />
            <InputFormField label="Ім'я" name='firstName' type='text' />
            <InputFormField label='Прізвище' name='lastName' type='text' />
            <InputFormField label='По-батькові' name='patronymic' type='text' />
            <Button
              type='submit'
              variant='contained'
              color='primary'
              size='large'
              sx={{ width: '60%' }}
            >
              Зберегти
            </Button>
            <ClearIcon className='close-icon' onClick={setClose} />
          </Form>
        )}
      </Formik>
    </Dialog>
  );
};

export { UserForm };

import React, { useState } from 'react';
import { Button, Dialog } from '@mui/material';
import { InputFormField } from '../InputFormField';
import { Formik, Form } from 'formik';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import regionalCenters from '../../const/cities';
import ClearIcon from '@mui/icons-material/Clear';
import ClubService from '../../services/ClubService';
import { Club } from '../../models/Club';

interface FormValues {
  id: number;
  name: string;
  address: string;
  city: string;
}

interface ClubFormProps {
  open: boolean;
  update: boolean;
  club?: Club;
  setClose: () => void;
}

const ClubForm = (props: ClubFormProps) => {
  const { open, update, club, setClose } = props;

  const initialValues: FormValues = {
    id: update ? club?.id || 0 : 0,
    name: update ? club?.name || '' : '',
    address: update ? club?.address || '': '',
    city: update ? club?.city || '': '',
  };

  const submitHandler = async (values: FormValues) => {
    const club: Club = {
      id: initialValues.id,
      name: values.name,
      city: values.city,
      address: values.address,
    };

    if (update){
      await ClubService.updateClub(club.id, club);
    }
    else{
      await ClubService.createClub(club);
    }
    
    setClose();
  };

  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
          <Form className='form'>
            <InputFormField label='Назва клубу' name='name' type='text' />
            <SelectForFilter
              label='Місто'
              items={regionalCenters}
              name={'city'}
              setFieldValue={setFieldValue}
            />
            <InputFormField label='Адреса' name='address' type='text' />

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

export { ClubForm };

function setValue(value: any) {
  throw new Error('Function not implemented.');
}


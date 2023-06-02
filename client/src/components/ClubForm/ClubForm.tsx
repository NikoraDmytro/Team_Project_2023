import React from 'react';
import { Button, Dialog } from '@mui/material';
import { InputFormField } from '../InputFormField';
import { Formik, Form } from 'formik';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import regionalCenters from '../../const/cities';
import ClearIcon from '@mui/icons-material/Clear';

interface FormValues {
  name: string;
  address: string;
  city: string;
}

const initialValues: FormValues = {
  name: '',
  address: '',
  city: '',
};

interface ClubFormProps {
  open: boolean;
  setClose: () => void;
}

const ClubForm = (props: ClubFormProps) => {
  const { open, setClose } = props;
  const submitHandler = (values: FormValues) => {
    console.log(values);
    setClose();
  };
  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {() => (
          <Form className='form'>
            <InputFormField label='Назва клубу' name='name' type='text' />
            <SelectForFilter label='Місто' items={regionalCenters} />
            <InputFormField label='Адреса' name='adrees' type='text' />

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

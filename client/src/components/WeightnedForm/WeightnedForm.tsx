import React from 'react';
import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import { InputFormField } from '../InputFormField';
import ClearIcon from '@mui/icons-material/Clear';

interface FormValues {
  kg: string;
  g: string;
}

const initialValues: FormValues = {
  kg: '',
  g: '',
};

interface WeightnedFormProps {
  open: boolean;
  setClose: () => void;
}

const WeightnedForm = (props: WeightnedFormProps) => {
  const { open, setClose } = props;
  const submitHandler = (values: FormValues) => {
    console.log(values);
    setClose();
  };
  return (
    <Dialog open={open} onClose={setClose} maxWidth='sm'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {() => (
          <Form className='form'>
            <InputFormField label='Kg' name='kg' type='text' />
            <InputFormField label='G' name='g' type='text' />
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

export { WeightnedForm };

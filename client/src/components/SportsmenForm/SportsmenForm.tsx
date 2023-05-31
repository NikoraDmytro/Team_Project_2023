import React from 'react';
import { Avatar, Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import { InputFormField } from '../InputFormField';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import ClearIcon from '@mui/icons-material/Clear';

interface FormValues {
  photo: string;
  firstname: string;
  lastname: string;
  patronimyc: string;
  sex: string;
  birthday: string;
  club: string;
  belt: string;
  coach: string;
  membershipCardNum: string;
}

const initialValues: FormValues = {
  photo: '',
  firstname: '',
  lastname: '',
  patronimyc: '',
  sex: '',
  birthday: '',
  club: '',
  belt: '',
  coach: '',
  membershipCardNum: '',
};

interface SportsmanFormProps {
  open: boolean;
  setClose: () => void;
}

const SportsmenForm = (props: SportsmanFormProps) => {
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
            <Avatar
              src={initialValues.photo}
              style={{ width: '60px', height: '60px' }}
            />
            <InputFormField
              label='Номер членського квитка'
              name='patronimyc'
              type='text'
            />
            <div className='inputs-group'>
              <InputFormField label='Прізвище' name='lastname' type='text' />
              <InputFormField label="Ім'я" name='firstname' type='text' />
            </div>
            <InputFormField
              label="Ім'я по-батькові"
              name='membershipCardNum'
              type='text'
            />
            <InputFormField
              label='Дата народження'
              name='weightingDate'
              type='date'
            />
            <div className='inputs-group'>
              <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
              <SelectForFilter label='Пояс' items={belts} />
            </div>
            <SelectForFilter label='Тренер' items={coachesTest} />
            <Button
              type='submit'
              variant='contained'
              color='primary'
              size='large'
              sx={{ width: '60%' }}
            >
              Додати спортсмена
            </Button>
            <ClearIcon className='close-icon' onClick={setClose} />
          </Form>
        )}
      </Formik>
    </Dialog>
  );
};

export { SportsmenForm };

const coachesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];

import React from 'react';
import { Avatar, Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import { InputFormField } from '../InputFormField';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import ClearIcon from '@mui/icons-material/Clear';
import coachesLevel from '../../const/coachesLevel';

interface FormValues {
  photo: string;
  firstname: string;
  lastname: string;
  patronimyc: string;
  sex: string;
  birthday: string;
  club: string;
  belt: string;
  coachCategory: string;
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
  coachCategory: '',
  membershipCardNum: '',
};

interface CoachFormProps {
  open: boolean;
  setClose: () => void;
}

const CoachForm = (props: CoachFormProps) => {
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
              name='patronimyc'
              type='text'
            />

            <div className='inputs-group'>
              <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
              <SelectForFilter label='Пояс' items={belts} />
            </div>
            <div className='inputs-group'>
              <InputFormField
                label='Дата народження'
                name='weightingDate'
                type='date'
              />
              <SelectForFilter label='Категорія' items={coachesLevel} />
            </div>
            <SelectForFilter label='Клуб' items={clubsTest} />
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

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
export { CoachForm };
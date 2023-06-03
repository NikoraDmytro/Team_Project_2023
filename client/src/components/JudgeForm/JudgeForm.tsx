import React from 'react';
import { Avatar, Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import { InputFormField } from '../InputFormField';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import ClearIcon from '@mui/icons-material/Clear';
import judgeCategory from '../../const/judgeCategory';

interface FormValues {
  photo: string;
  name: string;
  sex: string;
  birthday: string;
  club: string;
  belt: string;
  judgeCategory: string;
  membershipCardNum: string;
}

const initialValues: FormValues = {
  photo: '',
  name: '',
  sex: '',
  birthday: '',
  club: '',
  belt: '',
  judgeCategory: '',
  membershipCardNum: '',
};

interface JudgeFormProps {
  open: boolean;
  setClose: () => void;
}

const JudgeForm = (props: JudgeFormProps) => {
  const { open, setClose } = props;
  const submitHandler = (values: FormValues) => {
    console.log(values);
    setClose();
  };
  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
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
            <InputFormField label='ПІБ' name='name' type='text' />

            <div className='inputs-group'>
              <SelectForFilter
                label='Стать'
                items={['Ч', 'Ж']}
                name={'sex'}
                setFieldValue={setFieldValue}
              />
              <SelectForFilter
                label='Пояс'
                items={belts}
                name={'belt'}
                setFieldValue={setFieldValue}
              />
            </div>
            <div className='inputs-group'>
              <InputFormField
                label='Дата народження'
                name='weightingDate'
                type='date'
              />
              <SelectForFilter
                label='Категорія'
                items={judgeCategory}
                name={'judgeCategory'}
                setFieldValue={setFieldValue}
              />
            </div>
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

export { JudgeForm };

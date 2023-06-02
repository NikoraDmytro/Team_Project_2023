import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import React from 'react';
import { InputFormField } from '../InputFormField';
import ClearIcon from '@mui/icons-material/Clear';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import regionalCenters from '../../const/cities';
import competitionLevel from '../../const/competitionLevel';
import competitionStatus from '../../const/competitionStatus';

interface FormValues {
  competitionName: string;
  weightingDate: string;
  startDate: string;
  endData: string;
  city: string;
  status: string;
  level: string;
  address: string;
}

const initialValues: FormValues = {
  competitionName: '',
  weightingDate: '',
  startDate: '',
  endData: '',
  city: '',
  status: '',
  level: '',
  address: '',
};

interface CompetitionFormProps {
  open: boolean;
  setClose: () => void;
}

const CompetitionForm = (props: CompetitionFormProps) => {
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
            <InputFormField
              label='Назва змагання'
              name='competitionName'
              type='text'
            />
            <InputFormField
              label='Дата зважування'
              name='weightingDate'
              type='date'
            />
            <div className='inputs-group'>
              <InputFormField
                label='Дата початку'
                name='startDate'
                type='date'
              />
              <InputFormField
                label='Дата закінчення'
                name='endData'
                type='date'
              />
            </div>
            <SelectForFilter label='Місто' items={regionalCenters} />
            <InputFormField label='Адреса' name='adrees' type='text' />
            <div className='inputs-group'>
              <SelectForFilter label='Рівень' items={competitionLevel} />
              <SelectForFilter label='Статус' items={competitionStatus} />
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

export { CompetitionForm };

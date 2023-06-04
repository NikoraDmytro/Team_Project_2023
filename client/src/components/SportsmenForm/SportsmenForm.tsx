import React, { useEffect, useState } from 'react';
import { Avatar, Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import { InputFormField } from '../InputFormField';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import ClearIcon from '@mui/icons-material/Clear';
import { Sportsman } from '../../models/Sportsman';
import { BeltService, SportsmanService } from '../../services';
import { Belt } from '../../models/Belt';

interface FormValues {
  photo: string;
  firstname: string;
  lastname: string;
  patronymic: string;
  sex: string;
  birthdate: string;
  clubname: string;
  belt: string;
  coachname: string;
  membershipCardNum: string;
}

const initialValues: FormValues = {
  photo: '',
  firstname: '',
  lastname: '',
  patronymic: '',
  sex: '',
  birthdate: '',
  clubname: '',
  belt: '',
  coachname: '',
  membershipCardNum: '',
};

interface SportsmanFormProps {
  open: boolean;
  setClose: () => void;
}

const SportsmenForm = (props: SportsmanFormProps) => {
  const { open, setClose } = props;
  const [belts, setBelts] = useState<string[]>([]);

  const submitHandler = async (values: FormValues) => {
    const sportsman: Sportsman = {
      membershipCardNum: +values.membershipCardNum,
      firstName: values.firstname,
      lastName: values.lastname,
      patronymic: values.patronymic,
      birthDate: values.birthdate,
      sex: values.sex,
      clubName: values.clubname,
      belt: values.belt,
      coachName: values.coachname,
    };

    await SportsmanService.createSportsman(sportsman);
    setClose();
  };

  useEffect(() => {
    getBelts();
  }, []);

  const getBelts = async () => {
    var belts = (await BeltService.getAllBelts()).map(x => x.rank);
    setBelts(belts);
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
              name='membershipCardNum'
              type='text'
            />
            <div className='inputs-group'>
              <InputFormField label='Прізвище' name='lastname' type='text' />
              <InputFormField label="Ім'я" name='firstname' type='text' />
            </div>
            <InputFormField
              label="Ім'я по-батькові"
              name='patronymic'
              type='text'
            />
            <InputFormField
              label='Дата народження'
              name='birthdate'
              type='date'
            />
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
            <SelectForFilter
              label='Тренер'
              items={coachesTest}
              name={'coachname'}
              setFieldValue={setFieldValue}
            />
            <SelectForFilter
              label='Клуб'
              items={clubsTest}
              name={'clubname'}
              setFieldValue={setFieldValue}
            />
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

export { SportsmenForm };

const coachesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];
const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];

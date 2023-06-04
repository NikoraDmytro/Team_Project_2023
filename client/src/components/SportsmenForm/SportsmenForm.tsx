import React, { useEffect, useState } from 'react';
import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import ClearIcon from '@mui/icons-material/Clear';
import { Sportsman } from '../../models/Sportsman';
import { BeltService, SportsmanService } from '../../services';
import UserService from '../../services/UserService';
import CoachService from '../../services/CoachService';
import ClubService from '../../services/ClubService';

interface FormValues {
  membershipCardNum: number;
  sex: string;
  user: string;
  belt: string;
  coach: string;
}

interface SportsmanFormProps {
  open: boolean;
  update: boolean;
  sportsman?: Sportsman;
  setClose: () => void;
}

const SportsmenForm = (props: SportsmanFormProps) => {
  const { open, update, sportsman, setClose } = props;
  const [belts, setBelts] = useState<string[]>([]);
  const [users, setUsers] = useState<string[]>([]);
  const [coaches, setCoaches] = useState<string[]>([]);
  const [clubs, setClubs] = useState<string[]>([]);

  const initialValues: FormValues = {
    membershipCardNum: update ? sportsman?.membershipCardNum || 0 : 0,
    sex: update ? sportsman?.sex || '' : '',
    user: '',
    belt: '',
    coach: '',
  };

  const submitHandler = async (values: FormValues) => {
    const sportsman: any = {
      membershipCardNum: values.membershipCardNum,
      sex: values.sex,
      user: values.user,
      belt: values.belt,
      coach: values.coach,
    };

    if (update) {
      await SportsmanService.updateSportsman(
        initialValues.membershipCardNum,
        sportsman,
      );
    } else {
      await SportsmanService.createSportsman(sportsman);
    }

    setClose();
  };

  useEffect(() => {
    getBelts();
    getUsers();
    getCoaches();
    getClubs();
  }, []);

  const getBelts = async () => {
    var belts = (await BeltService.getAllBelts()).map(x => x.rank);
    setBelts(belts);
  };

  const getUsers = async () => {
    var users = (await UserService.getAllUsers()).map(
      x => x.firstName + ' ' + x.lastName,
    );
    setUsers(users);
  };

  const getCoaches = async () => {
    var coaches = (await CoachService.getAllCoaches()).map(
      x => x.firstName + ' ' + x.lastName,
    );
    setCoaches(coaches);
  };

  const getClubs = async () => {
    var clubs = (await ClubService.getAllClubs()).map(x => x.name);
    setClubs(clubs);
  };

  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
          <Form className='form'>
            <div className='inputs-group'>
              <SelectForFilter
                label='Користувач'
                items={users}
                name={'user'}
                setFieldValue={setFieldValue}
              />
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
              items={coaches}
              name={'coach'}
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

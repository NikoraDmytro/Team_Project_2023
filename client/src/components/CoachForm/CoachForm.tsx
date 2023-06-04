import { useEffect, useState } from 'react';
import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import ClearIcon from '@mui/icons-material/Clear';
import coachesLevel from '../../const/coachesLevel';
import { CoachService } from '../../services';
import { Coach } from '../../models/Coach';
import ClubService from '../../services/ClubService';
import SportsmanService from '../../services/SportsmanService';
import InstructorCategoryService from '../../services/InstructorCategoryService';
import { InputFormField } from '../InputFormField';

interface FormValues {
  membershipCardNum: number;
  sportsman: string;
  club: string;
  coachCategory: string;
  phone: string;
}

interface CoachFormProps {
  open: boolean;
  update: boolean;
  coach?: Coach;
  setClose: () => void;
}

const CoachForm = (props: CoachFormProps) => {
  const { open, update, coach, setClose } = props;
  const [clubs, setClubs] = useState<string[]>([]);
  const [sportsmen, setSportsmen] = useState<string[]>([]);
  const [instructorCategories, setInstructorCategories] = useState<string[]>(
    [],
  );

  const initialValues: FormValues = {
    membershipCardNum: update ? coach?.membershipCardNum || 0 : 0,
    sportsman: '',
    club: '',
    coachCategory: '',
    phone: update ? coach?.phone || '' : '',
  };

  const fetchClubs = async () => {
    const response = await ClubService.getAllClubs();
    setClubs(response.map(x => x.name));
  };

  const fetchSportsmen = async () => {
    const response = await SportsmanService.getAllSportsmen();
    setSportsmen(response.map(x => x.firstName + ' ' + x.lastName));
  };

  const fetchInstructorCategories = async () => {
    const response =
      await InstructorCategoryService.getAllInstructorCategories();
    setInstructorCategories(response.map(x => x.name));
  };

  useEffect(() => {
    fetchClubs();
    fetchSportsmen();
    fetchInstructorCategories();
  }, []);

  const submitHandler = async (values: FormValues) => {
    const coach: any = {
      membershipCardNum: values.membershipCardNum,
      phone: values.phone,
      sportsman: values.sportsman,
      club: values.club,
      instructorCategory: values.coachCategory,
    };

    if (update) {
      await CoachService.updateCoach(coach.membershipCardNum, coach);
    } else {
      await CoachService.createCoach(coach);
    }

    setClose();
  };

  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
          <Form className='form'>
            <div>
              <div className='inputs-group'>
                <InputFormField
                  label='Номер телефону'
                  name='phone'
                  type='text'
                />
                <SelectForFilter
                  label='Спортсмен'
                  items={sportsmen}
                  name={'sportsman'}
                  setFieldValue={setFieldValue}
                />
              </div>
              <div className='inputs-group'>
                <SelectForFilter
                  label='Категорія'
                  items={instructorCategories}
                  name={'coachCategory'}
                  setFieldValue={setFieldValue}
                />
              </div>
              <SelectForFilter
                label='Клуб'
                items={clubs}
                name={'club'}
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
                name='birthDate'
                type='date'
              />
              <SelectForFilter
                label='Категорія'
                items={coachesLevel}
                name={'coachCategory'}
                setFieldValue={setFieldValue}
              />
            </div>
            <SelectForFilter
              label='Клуб'
              items={clubs}
              name={'club'}
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

export { CoachForm };

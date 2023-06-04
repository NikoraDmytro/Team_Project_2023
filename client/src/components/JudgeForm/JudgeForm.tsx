import { useEffect, useState } from 'react';
import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import ClearIcon from '@mui/icons-material/Clear';
import JudgeCategoryService from '../../services/JudgeCategoryService';
import SportsmanService from '../../services/SportsmanService';
import JudgeService from '../../services/JudgeService';
import { Judge } from '../../models/Judge';

interface FormValues {
  membershipCardNum: number;
  sportsman: string;
  judgeCategory: string;
}

interface JudgeFormProps {
  open: boolean;
  update: boolean;
  judge?: Judge;
  setClose: () => void;
}

const JudgeForm = (props: JudgeFormProps) => {
  const { open, update, judge, setClose } = props;
  const [sportsmen, setSportsmen] = useState<string[]>([]);
  const [judgeCategories, setJudgeCategories] = useState<string[]>([]);

  const initialValues: FormValues = {
    membershipCardNum: update ? judge?.membershipCardNum || 0 : 0,
    sportsman: '',
    judgeCategory: '',
  };

  const submitHandler = async (values: FormValues) => {
    if (update) {
      await JudgeService.updateJudge(initialValues.membershipCardNum, values);
    } else {
      await JudgeService.createJudge(values);
    }

    setClose();
  };

  const fetchSportsmen = async () => {
    var sportsmen = await SportsmanService.getAllSportsmen();
    setSportsmen(sportsmen.map(x => x.firstName + ' ' + x.lastName));
  };

  const fetchJudgeCategories = async () => {
    var judgeCategories = await JudgeCategoryService.getAllJudgeCategories();
    setJudgeCategories(judgeCategories.map(x => x.name));
  };

  useEffect(() => {
    fetchSportsmen();
    fetchJudgeCategories();
  }, []);

  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
          <Form className='form'>
            <div className='inputs-group'>
              <SelectForFilter
                label='Спортсмен'
                items={sportsmen}
                name={'sportsman'}
                setFieldValue={setFieldValue}
              />
              <SelectForFilter
                label='Категорія'
                items={judgeCategories}
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

import { Button, Dialog } from '@mui/material';
import { Formik, Form } from 'formik';
import React, { useEffect, useState } from 'react';
import { InputFormField } from '../InputFormField';
import ClearIcon from '@mui/icons-material/Clear';
import SelectForFilter from '../SelectForFilter/SelectForFilter';
import regionalCenters from '../../const/cities';
import CompetitionStatusService from '../../services/CompetitionStatusService';
import CompetitionLevelService from '../../services/CompetitionLevelService';
import CompetitionService from '../../services/CompetitionService';
import { Competition } from '../../models/Competition';

interface FormValues {
  id: number;
  name: string;
  weightingDate: string;
  startDate: string;
  endDate: string;
  city: string;
  status: string;
  level: string;

}

interface CompetitionFormProps {
  open: boolean;
  update: boolean;
  competition?: Competition;
  setClose: () => void;
}

const CompetitionForm = (props: CompetitionFormProps) => {
  const { open, update, competition, setClose } = props;
  const [competitionLevels, setCompetitionLevels] = useState<string[]>([]);
  const [competitionStatuses, setCompetitionStatuses] = useState<string[]>([]);

  const initialValues: FormValues = {
    id: update ? competition?.competitionId || 0 : 0,
    name: update ? competition?.name || '' : '',
    weightingDate: update ? competition?.weightingDate || '' : '',
    startDate: update ? competition?.startDate || '' : '',
    endDate: update ? competition?.endDate || '' : '',
    city: update ? competition?.city || '' : '',
    status: update ? competition?.status || '' : '',
    level: update ? competition?.level || '' : '',
  }

  const fetchCompetitionStatuses = async () => {
    var competitionStatuses = await CompetitionStatusService.getAllCompetitionStatuses();
    setCompetitionStatuses(competitionStatuses.data.map(x => x.name));
  }

  const fetchCompetitionLevels = async () => {
    var competitionLevels = await CompetitionLevelService.getAllCompetitionLevels();
    setCompetitionLevels(competitionLevels.data.map(x => x.name));
  }

  useEffect(() => {
    fetchCompetitionStatuses();
    fetchCompetitionLevels();
  }, []);
  
  const submitHandler = async (values: FormValues) => {
    const competition: any = {
      id: initialValues.id,
      name: values.name,
      weightingDate: values.weightingDate,
      startDate: values.startDate,
      endDate: values.endDate,
      city: values.city,
      status: values.status,
      level: values.level,
    };

    if (update){
      await CompetitionService.updateCompetition(competition.id, competition);
    }
    else{
      await CompetitionService.createCompetition(competition);
    }
    
    setClose();
  };
  return (
    <Dialog open={open} onClose={setClose} maxWidth='lg'>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {({ setFieldValue }) => (
          <Form className='form'>
            <InputFormField
              label='Назва змагання'
              name='name'
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
                name='endDate'
                type='date'
              />
            </div>
            <SelectForFilter
              label='Місто'
              items={regionalCenters}
              name={'city'}
              setFieldValue={setFieldValue}
            />
            <div className='inputs-group'>
              <SelectForFilter
                label='Рівень'
                items={competitionLevels}
                name={'level'}
                setFieldValue={setFieldValue}
              />
              <SelectForFilter
                label='Статус'
                items={competitionStatuses}
                name={'status'}
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

export { CompetitionForm };

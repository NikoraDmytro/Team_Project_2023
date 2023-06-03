import React, { useEffect, useState } from 'react';
import { TableColumns } from '../../types/DataTableTypes';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { DataTable } from '../../components/DataTable';
import belts from '../../const/belts';
import coachesLevel from '../../const/coachesLevel';
import './CoachesPage.scss';
import { CoachForm } from '../../components/CoachForm';
import CoachService from '../../services/CoachService';

type Coach = (typeof test)[0];
type ColumnsType = Coach & { controls: string };

const CoachesPage = () => {
  const [coaches, setCoaches] = useState(test);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const fetchCoaches = async () => {
    const response = await CoachService.getAllCoaches();
    const coachesData = response.data.map((coach) => ({
      membershipCardNum: coach.membershipCardNum,
      name: coach.firstName,
      sex: coach.sex,
      birthDate: coach.birthDate,
      clubName: coach.clubName,
      belt: coach.belt,
      instructorCategory: coach.instructorCategory
    }));
    setCoaches(coachesData);
  };

  useEffect(() => {
    fetchCoaches();
  }, []);

  const columns: TableColumns<Coach, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'birthDate',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'clubName',
      label: 'Клуб',
    },
    {
      name: 'instructorCategory',
      label: 'Інструкторська категорія',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'controls',
      renderItem: () => (
        <div className='control-buttons'>
          <EditIcon onClick={() => setOpen(true)} />
          <DeleteIcon className='delete-icon' />
        </div>
      ),
    },
  ];
  return (
    <div className='wrapper'>
      <div className='menu'>
        <TextField label='Пошук'></TextField>
        <div className='filter-buttons'>
          <div className='first-buttons'>
            <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
            <SelectForFilter label='Пояс' items={belts} />
          </div>
          <div className='second-buttons'>
            <SelectForFilter label='Клуб' items={clubsTest} />
            <SelectForFilter label='Категорія' items={coachesLevel} />
          </div>
        </div>
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Додати тренера
        </Button>
      </div>

      <DataTable tableData={coaches} tableColumns={columns} />
      <CoachForm open={open} setClose={handleClose} />
    </div>
  );
};

export { CoachesPage };

const test = [
  {
    membershipCardNum: 1,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
  {
    membershipCardNum: 2,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
  {
    membershipCardNum: 3,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
  {
    membershipCardNum: 4,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
  {
    membershipCardNum: 5,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
  {
    membershipCardNum: 6,
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    belt: '1 дан',
    birthDate: '2005-02-06',
    clubName: 'СК "ПРАЙД"',
    instructorCategory: 'Тренер національного класу',
  },
];
const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];

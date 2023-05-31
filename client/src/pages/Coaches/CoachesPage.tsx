import React, { useState } from 'react';
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

type Coach = (typeof test)[0];
type ColumnsType = Coach & { controls: string };

const CoachesPage = () => {
  const [coaches, setCoaches] = useState(test);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const columns: TableColumns<Coach, ColumnsType>[] = [
    {
      name: 'photo',
      label: 'Фото',
    },
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
      name: 'birthday',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'club',
      label: 'Клуб',
    },
    {
      name: 'belt',
      label: 'Статус',
    },
    {
      name: 'coachCategory',
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
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
  {
    id: 2,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
  {
    id: 3,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
  {
    id: 4,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
  {
    id: 5,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
  {
    id: 6,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coachCategory: 'Тренер національного класу',
    membershipCardNum: '123456',
  },
];
const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];

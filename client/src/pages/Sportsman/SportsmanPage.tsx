import React, { useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import belts from '../../const/belts';
import './Sportsman.scss';
import { SportsmenForm } from '../../components/SportsmenForm';

type Sporstman = (typeof test)[0];
type ColumnsType = Sporstman & { controls: string };

const SportsmanPage = () => {
  const [sportsmen, setSportsmen] = useState(test);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const columns: TableColumns<Sporstman, ColumnsType>[] = [
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
      name: 'coach',
      label: 'Прокопенко Ю.С.',
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
        <TextField label='Пошук' />
        <div className='groups-filters'>
          <div className='filter-buttons1'>
            <SelectForFilter label='Стать' items={['Ч', 'Ж']} />
            <SelectForFilter label='Клуб' items={clubsTest} />
            <SelectForFilter label='Тренер' items={coachesTest} />
          </div>
          <div className='filter-buttons2'>
            <SelectForFilter label='Мін пояс' items={belts} />
            <SelectForFilter label='Макс пояс' items={belts} />
            <TextField label='Мін вік' />
            <TextField label='Макс вік' />
          </div>
        </div>
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Додати спортсмена
        </Button>
      </div>
      <DataTable tableData={sportsmen} tableColumns={columns} />
      <SportsmenForm open={open} setClose={handleClose} />
    </div>
  );
};

export { SportsmanPage };

const test = [
  {
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
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
    coach: 'Прокопенко Ю.С.',
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
    coach: 'Прокопенко Ю.С.',
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
    coach: 'Прокопенко Ю.С.',
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
    coach: 'Прокопенко Ю.С.',
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
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
  {
    id: 7,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    club: 'СК "ПРАЙД"',
    belt: '1 дан',
    coach: 'Прокопенко Ю.С.',
    membershipCardNum: '123456',
  },
];

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];
const coachesTest = ['Прокопенко Ю.С.', 'Прокопенко Ю.С.', 'Прокопенко Ю.С.'];

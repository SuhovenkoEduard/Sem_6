import React, { useEffect, useState } from 'react'
import { Button, Form } from 'react-bootstrap'
import { CourierGroupedReports } from '../../../../constants/types'
import { FormText } from '../../../../common/FormText'
import { ReportVisualizer } from './ReportVisualizer'
import { FormInput } from '../../../../common/FormInput'

type GroupedReportsVisualizerProps = {
  groupedReports: CourierGroupedReports
  isFullShown: boolean
  editCourierSalary: (courierId: number, salary: number) => Promise<void>
}

export const GroupedReportsVisualizer = ({
  groupedReports,
  isFullShown,
  editCourierSalary,
}: GroupedReportsVisualizerProps) => {
  const {
    courier,
    reports,
  } = groupedReports

  const [isReportsOpen, setIsReportsOpen] = useState<boolean>(false)
  const [courierSalary, setCourierSalary] = useState<string>(courier.salary.toString())
  const [isSalaryEditModeEnabled, setIsSalaryEditModeEnabled] = useState<boolean>(false)
  const toggleReports = () => setIsReportsOpen(!isReportsOpen)

  useEffect(() => setIsReportsOpen(isFullShown), [isFullShown])
  useEffect(() => setCourierSalary(courier.salary.toString()), [courier.salary])

  const onSalaryEditCancel = () => {
    setCourierSalary(courier.salary.toString())
    setIsSalaryEditModeEnabled(false)
  }

  const onSalaryEditSave = (e: React.SyntheticEvent) => {
    e.preventDefault()
    if (courier.salary.toString() !== courierSalary) {
      editCourierSalary(courier.id, +courierSalary).then(() => {
        setIsSalaryEditModeEnabled(false)
      })
    } else {
      onSalaryEditCancel()
    }
  }

  return (
    <div className="p-2 border border-3 rounded-3 w-100">
      <FormText label="Courier Name" value={courier.name} />
      {isSalaryEditModeEnabled ? (
        <Form onSubmit={onSalaryEditSave}>
          <FormInput required className="w-25" type="number" name="salary" label="Salary" value={courierSalary} onChange={(_, value) => setCourierSalary(value)} />
          <Button className="m-2" onClick={onSalaryEditCancel}>Cancel.</Button>
          <Button className="m-2" type="submit">Save.</Button>
        </Form>
      ) : (
        <>
          <FormText label="Salary" value={courier.salary.toString()} />
          <Button className="m-2" onClick={() => setIsSalaryEditModeEnabled(true)}>Edit.</Button>
        </>
      )}
      <FormText label="Description" value={courier.description} />
      <Form.Group>
        <Form.Label className="mt-2">Reports</Form.Label>
        {isReportsOpen ? (
          <>
            <Button className="mx-2" onClick={toggleReports}>Hide reports.</Button>
            <div className="m-2 p-2 border border-3 d-grid gap-2 rounded">
              {/* eslint-disable-next-line max-len */}
              {reports.map((report) => <ReportVisualizer key={report.id} report={report} isFullShown={isFullShown} />)}
            </div>
          </>
        ) : (
          <Button className="mx-2" variant="outline-dark" onClick={toggleReports}>Show reports</Button>
        )}
      </Form.Group>
    </div>
  )
}

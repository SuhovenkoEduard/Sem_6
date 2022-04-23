import React, { useEffect, useState } from 'react'
import { Button, Form } from 'react-bootstrap'
import { FullReport } from '../../../../constants/types'
import { FormText } from '../../../../common/FormText'

type ReportVisualizerProps = {
  report: FullReport
  isFullShown: boolean
}

export const ReportVisualizer = ({ report, isFullShown }: ReportVisualizerProps) => {
  const [isReportDetailsShown, setIsReportDetailsShown] = useState<boolean>(false)
  const toggleReportDetails = () => setIsReportDetailsShown(!isReportDetailsShown)

  useEffect(() => setIsReportDetailsShown(isFullShown), [isFullShown])

  return (
    <div className="rounded border border-3 p-2">
      <FormText label="Report Date" value={report.date} />
      <FormText label="Report Description" value={report.description} />
      <Form.Group>
        <Form.Label className="mt-2">Report details</Form.Label>
        {isReportDetailsShown ? (
          <>
            <Button className="mx-2" onClick={toggleReportDetails}>Hide details.</Button>
            <div className="m-2 p-2 border border-3 rounded d-flex flex-row gap-3">
              <span>
                <img style={{ height: '100px', width: '100px' }} src={report.order.pizza.imageUrl} alt="" />
              </span>
              <span>
                <div>{`Pizza's Name: ${report.order.pizza.name}`}</div>
                <div>{`Pizza's Price: ${report.order.pizza.price}$`}</div>
                <div>{`Pizza's Description: ${report.order.pizza.description}`}</div>
              </span>
            </div>
          </>
        ) : (
          <Button className="mx-2" variant="outline-dark" onClick={toggleReportDetails}>Show details</Button>
        )}
      </Form.Group>
    </div>
  )
}

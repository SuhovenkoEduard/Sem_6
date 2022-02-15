#pragma once

class Section {

	private:
		double x1, x2, y1, y2;

	public:

		Section(double X1, double X2, double Y1, double Y2);

		bool _IsParallelToOX();
		double _GetLength();
};

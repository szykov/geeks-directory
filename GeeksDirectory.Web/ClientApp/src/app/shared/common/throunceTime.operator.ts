import { merge, Observable, MonoTypeOperatorFunction } from 'rxjs';
import { throttleTime, debounceTime } from 'rxjs/operators';

export function throunceTime<T>(duration: number): MonoTypeOperatorFunction<T> {
	return (source: Observable<T>): Observable<T> =>
		merge(source.pipe(throttleTime(duration)), source.pipe(debounceTime(duration))).pipe(
			throttleTime(0, undefined, { leading: true, trailing: false })
		);
}

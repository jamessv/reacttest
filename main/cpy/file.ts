describe('an essay on the best flavor', () => {
    test('mentions grapefruit', () => {
      expect(essayOnTheBestFlavor()).toMatch(/grapefruit/);
      expect(essayOnTheBestFlavor()).toMatch(new RegExp('grapefruit'));
    });
  });